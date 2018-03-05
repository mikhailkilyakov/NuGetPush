namespace NuGetPush.Settings
{
    using System;
    using Newtonsoft.Json;

    public class NuGetSource
    {
        [Obsolete("Only for reflection", true)]
        public NuGetSource() { }

        public NuGetSource(string name, string url, string key)
        {
            Id = Guid.NewGuid().ToString();
            SetName(name);
            SetUrl(url);
            SetKey(key);
        }

        [JsonProperty]
        public string Id { get; protected set; }

        [JsonProperty]
        public string Name { get; protected set; }

        [JsonProperty]
        public string Url { get; protected set; }

        [JsonProperty]
        public string Key { get; protected set; }

        public override string ToString()
        {
            return Name ?? base.ToString();
        }

        public void SetName(string name)
        {
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void SetUrl(string url)
        {
            url = url?.Trim();

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            Url = url;
        }

        public void SetKey(string key)
        {
            Key = key;
        }
    }
}