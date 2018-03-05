namespace NuGetPush.Settings
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    public class NuGetSourcesCollection : IDisposable
    {
        private static readonly JsonSerializer Json = JsonSerializer.CreateDefault();
        private const string SettingsFileName = "settings.json";
        private static NuGetSourcesCollection _instance;
        private readonly string _settingsPath;
        private readonly List<NuGetSource> _sources = new List<NuGetSource>();
        
        private NuGetSourcesCollection()
        {
            _settingsPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Restore();
        }

        private string SettingsFilePath => Path.Combine(_settingsPath, SettingsFileName);

        public static NuGetSourcesCollection Instance => _instance ?? (_instance = new NuGetSourcesCollection());

        public IReadOnlyList<NuGetSource> Sources => _sources;

        public void Add(NuGetSource source)
        {
            if (_sources.Any(x => string.Equals(x.Id, source.Id, StringComparison.InvariantCultureIgnoreCase)))
                return;

            if (_sources.Any(x => string.Equals(x.Name, source.Name, StringComparison.InvariantCultureIgnoreCase)))
                throw new InvalidOperationException("Source with same name already exists");

            _sources.Add(source);
            Store();
        }

        public void Edit(NuGetSource source, string name, string url, string key)
        {
            if (_sources.All(x => !string.Equals(x.Id, source.Id)))
                throw new InvalidOperationException("Source not found");

            if (_sources.Any(x => !string.Equals(source.Id, x.Id, StringComparison.InvariantCultureIgnoreCase) && string.Equals(x.Name, source.Name, StringComparison.InvariantCultureIgnoreCase)))
                throw new InvalidOperationException("Source with same name already exists");

            source.SetName(name);
            source.SetUrl(url);
            source.SetKey(key);

            Store();
        }

        public void Remove(NuGetSource source)
        {
            if (_sources.All(x => !string.Equals(x.Id, source.Id)))
                throw new InvalidOperationException("Source not found");

            var s = _sources.First(x => string.Equals(x.Id, source.Id, StringComparison.InvariantCultureIgnoreCase));
            _sources.Remove(s);

            Store();
        }

        public bool Contains(NuGetSource source)
        {
            return _sources.Any(x => x == source);
        }

        private void Restore()
        {
            if (!File.Exists(SettingsFilePath))
                return;

            using (StreamReader streamReader = new StreamReader(SettingsFilePath))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    var sources = Json.Deserialize<IEnumerable<NuGetSource>>(jsonTextReader);
                    _sources.Clear();
                    _sources.AddRange(sources);
                }
            }
        }

        private void Store()
        {
            using (StreamWriter streamWriter = new StreamWriter(SettingsFilePath, false))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    Json.Serialize(jsonTextWriter, _sources);
                }
            }
        }
        
        public void Dispose()
        {
            Store();
        }
    }
}