using System;
using System.Configuration;
using System.Windows.Forms;

namespace MazeNavigatorUI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            //ConfigurationManager.RefreshSection("appSettings");

            // Load the values from the config
            txtRows.Text = ConfigurationManager.AppSettings["mazeRows"];
            txtColumns.Text = ConfigurationManager.AppSettings["mazeColumns"];
            txtAnimationSpeed.Text = ConfigurationManager.AppSettings["animationSpeed"];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //// TODO: This is not saving.
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            //config.AppSettings.Settings.Add("mazeRows", txtRows.Text);
            //config.AppSettings.Settings.Add("mazeColumns", txtColumns.Text);
            //config.AppSettings.Settings.Add("animationSpeed", txtAnimationSpeed.Text);

            //config.Save(ConfigurationSaveMode.Full);

            this.Close();
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtColumns_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtAnimationSpeed_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
