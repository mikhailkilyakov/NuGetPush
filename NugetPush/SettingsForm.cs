namespace NuGetPush
{
    using System;
    using System.Windows.Forms;
    using Settings;

    public partial class SettingsForm : Form
    {
        private readonly NuGetSourcesCollection _sources = NuGetSourcesCollection.Instance;
        private NuGetSource _currentSource;
        private SettingsFormStates _state = SettingsFormStates.View;

        public SettingsForm()
        {
            InitializeComponent();
            UpdateByState();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _state = SettingsFormStates.Add;
            UpdateByState();
        }

        private void UpdateByState()
        {
            switch (_state)
            {
                case SettingsFormStates.View:
                    nuGetSourcesListBox.Enabled = true;
                    addButton.Enabled = true;
                    editButton.Enabled = _currentSource != null;
                    removeButton.Enabled = _currentSource != null;

                    nameTextBox.ReadOnly = true;
                    keyTextBox.ReadOnly = true;
                    urlTextBox.ReadOnly = true;
                    saveButton.Enabled = false;
                    cancelButton.Enabled = false;
                    

                    if (_currentSource == null)
                    {
                        nameTextBox.Text = "";
                        keyTextBox.Text = "";
                        urlTextBox.Text = "";
                    }
                    else
                    {
                        nameTextBox.Text = _currentSource.Name;
                        keyTextBox.Text = _currentSource.Key;
                        urlTextBox.Text = _currentSource.Url;
                    }
                    break;

                case SettingsFormStates.Add:
                    nuGetSourcesListBox.Enabled = false;
                    addButton.Enabled = false;
                    editButton.Enabled = false;
                    removeButton.Enabled = false;

                    nameTextBox.ReadOnly = false;
                    nameTextBox.Text = "New source";

                    keyTextBox.ReadOnly = false;
                    keyTextBox.Text = "012345679ABCDEF";

                    urlTextBox.ReadOnly = false;
                    urlTextBox.Text = "http://nuget.company.org/";

                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
                case SettingsFormStates.Edit:
                    nuGetSourcesListBox.Enabled = false;
                    addButton.Enabled = false;
                    editButton.Enabled = false;
                    removeButton.Enabled = false;

                    nameTextBox.ReadOnly = false;
                    keyTextBox.ReadOnly = false;
                    urlTextBox.ReadOnly = false;
                    nameTextBox.Text = _currentSource.Name;
                    keyTextBox.Text = _currentSource.Key;
                    urlTextBox.Text = _currentSource.Url;

                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            UpdateItems();
        }

        private void UpdateItems()
        {
            nuGetSourcesListBox.Items.Clear();
            foreach (var source in _sources.Sources)
                nuGetSourcesListBox.Items.Add(source);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _state = SettingsFormStates.View;
            UpdateByState();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (_state)
            {
                case SettingsFormStates.Add:
                    try
                    {
                        NuGetSource nuGetSource = new NuGetSource(nameTextBox.Text, urlTextBox.Text, keyTextBox.Text);
                        _sources.Add(nuGetSource);
                        _state = SettingsFormStates.View;
                        UpdateItems();
                        UpdateByState();
                    }
                    catch (Exception exception)
                    {
                        exception.ShowError();
                    }
                    break;
                case SettingsFormStates.Edit:
                    try
                    {
                        _sources.Edit(_currentSource, nameTextBox.Text, urlTextBox.Text, keyTextBox.Text);
                        _state = SettingsFormStates.View;
                        UpdateItems();
                        UpdateByState();
                    }
                    catch (Exception exception)
                    {
                        exception.ShowError();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void nuGetSourcesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSource = null;

            if (nuGetSourcesListBox.SelectedItem != null)
            {
                _currentSource = nuGetSourcesListBox.SelectedItem as NuGetSource;
            }

            UpdateByState();
        }
        
        private void editButton_Click(object sender, EventArgs e)
        {
            _state = SettingsFormStates.Edit;
            UpdateByState();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                _sources.Remove(_currentSource);
                _currentSource = null;
                UpdateItems();
                UpdateByState();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }
    }
}
