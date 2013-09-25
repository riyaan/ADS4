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
            ConfigurationManager.AppSettings.Set("mazeRows", txtRows.Text);
            ConfigurationManager.AppSettings.Set("mazeColumns", txtColumns.Text);
            ConfigurationManager.AppSettings.Set("animationSpeed", txtAnimationSpeed.Text);

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
