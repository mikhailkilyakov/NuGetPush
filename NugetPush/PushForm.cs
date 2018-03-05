namespace NuGetPush
{
    using System;
    using System.Windows.Forms;
    using Settings;

    public partial class PushForm : Form
    {
        private readonly string _packagePath;
        private readonly NuGetSourcesCollection _sourcesCollection = NuGetSourcesCollection.Instance;

        public PushForm(string packagePath)
        {
            _packagePath = packagePath;
            InitializeComponent();
        }

        private void UpdateItems()
        {
            nuGetSourcesComboBox.Items.Clear();

            foreach (var source in _sourcesCollection.Sources)
                nuGetSourcesComboBox.Items.Add(source);

            if (nuGetSourcesComboBox.Items.Count > 0)
                nuGetSourcesComboBox.SelectedIndex = 0;
            else
                pushButton.Enabled = nuGetSourcesComboBox.SelectedItem != null;
        }

        private void PushForm_Load(object sender, System.EventArgs e)
        {
            packageFilePathTextBox.Text = _packagePath;
            UpdateItems();
        }

        private void nuGetSourcesComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            pushButton.Enabled = nuGetSourcesComboBox.SelectedItem != null;
        }

        private void pushButton_Click(object sender, System.EventArgs e)
        {
            if (nuGetSourcesComboBox.SelectedItem is NuGetSource source)
            {
                try
                {
                    Hide();
                    NuGet.TryPush(source.Url, source.Key, _packagePath);
                    MessageBox.Show("Pushed successfully!", "NuGetPush");
                    Close();
                }
                catch (Exception exception)
                {
                    exception.ShowError();
                    Show();
                }
            }
        }

        private void settingsButton_Click(object sender, System.EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            UpdateItems();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
