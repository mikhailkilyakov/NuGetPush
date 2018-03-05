namespace NuGetPush
{
    using System;
    using System.Windows.Forms;

    public static class ExceptionExtensions
    {
        public static void ShowError(this Exception exception)
        {
            MessageBox.Show($@"An error has occured: {exception.Message}", @"NuGetPush", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}