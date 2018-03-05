namespace NuGetPush
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using Settings;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower() == "--register")
                {
                    Register();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new PushForm(args[0]));
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SettingsForm());
            }

            NuGetSourcesCollection.Instance?.Dispose();
        }

        static void Register()
        {
            try
            {
                var hkcr = Registry.ClassesRoot;

                RegistryKey nuPkgKey = hkcr.GetSubKeyNames().Contains(".nupkg")
                    ? hkcr.OpenSubKey(".nupkg", true)
                    : hkcr.CreateSubKey(".nupkg");

                RegistryKey shellKey = nuPkgKey.GetSubKeyNames().Contains("shell")
                    ? nuPkgKey.OpenSubKey("shell", true)
                    : nuPkgKey.CreateSubKey("shell");

                if (shellKey.GetSubKeyNames().Contains("push"))
                    shellKey.DeleteSubKeyTree("push");

                var pushKey = shellKey.CreateSubKey("push");
                pushKey.SetValue("", "Push to NuGet...");
                var commandKey = pushKey.CreateSubKey("command");
                commandKey.SetValue("", $"{Assembly.GetEntryAssembly().Location.Replace("\\", "\\\\")} %1");

                MessageBox.Show($"Registered in system successfully!{Environment.NewLine}Now just double-click any .nupkg file to push it.", "NuGetPush");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
