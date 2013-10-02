using Controllers;
using Entities;
using Entities.Maze;
using SharedEvents;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace MazeNavigatorUI
{
    public partial class NavigatorUI : Form
    {        
        public int Rows { get; set; }        
        public int Columns { get; set; }
        public Random Random { get; set; }        
        public Maze Maze { get; set; }        

        private UIController _uiController;
        private bool _isRunning;

        public NavigatorUI()
        {
            InitializeComponent();

            mazeLayoutPanel.Size = new System.Drawing.Size(this.Height, this.Width);

            _uiController = new UIController();
            _uiController.ArrowChanged += _uiController_ArrowChanged;            
        }

        void _uiController_ArrowChanged(object sender, ArrowChangedEventArgs e)
        {
            if (_isRunning)
            {
                Diagnostics.Logger.Instance.Log("Handling the arrow changed event.");
                ArrowContext ac = e.Arrow;
                Diagnostics.Logger.Instance.Log("Current State: " + ac.CurrentState.ToString());
                Diagnostics.Logger.Instance.Log(String.Format("X:{0} Y:{1}", ac.X, ac.Y));

                string direction = String.Empty;
                if (ac.CurrentState.ToString().ToUpper().Contains("RIGHT"))
                    direction = "R";
                else if (ac.CurrentState.ToString().ToUpper().Contains("LEFT"))
                    direction = "L";
                else if (ac.CurrentState.ToString().ToUpper().Contains("FORWARD"))
                    direction = "F";

                UpdateGrid(ac.X, ac.Y, direction);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
            GenerateMaze();
            CreateMazeVisually();
            UpdateGrid(0, 0, "F");
            _isRunning = true;
        }

        private void GenerateMaze()
        {
            // Get the values from the configuration file
            ConfigurationManager.RefreshSection("appSettings");
            Rows = Int32.Parse(ConfigurationManager.AppSettings["mazeRows"]);
            Columns = Int32.Parse(ConfigurationManager.AppSettings["mazeColumns"]);

            // UI Controller interacts with the Maze Controller            
            Maze = _uiController.GenerateNewMaze(Rows, Columns);
        }

        private void CreateMazeVisually()
        {
            Diagnostics.Logger.Instance.Log("Creating maze visually.");

            try
            {

                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        Go();
                        UpdateGrid(0, 0, "F");
                    });
                }
                else
                {
                    Go();
                    UpdateGrid(0, 0, "F");
                }
            }
            catch (Exception ex)
            {
                Diagnostics.Logger.Instance.Log(ex.Message);
            }
        }

        private void Go()
        {
            // http://www.richard-banks.org/2007/09/how-to-create-flicker-free.html
            // This helps get rid of flickering
            mazeLayoutPanel.Visible = false;
            mazeLayoutPanel.SuspendLayout();
            
            mazeLayoutPanel.Controls.Clear();
            mazeLayoutPanel.RowCount = Maze.Rows;
            mazeLayoutPanel.ColumnCount = Maze.Columns;            

            int k = 0;
            int l = 0;
            for (int i = Maze.Rows - 1; i >= 0; i--)
            {
                for (int j = Maze.Columns - 1; j >= 0; j--)
                {
                    Button b = new Button
                    {
                        Name = Maze.Grid[i, j].XCoordinate + "_" + Maze.Grid[i, j].YCoordinate,
                        Size = new Size(26, 23)
                    };

                    if (Maze.Grid[i, j].CellState == CELL_STATE.OPEN)
                        b.BackColor = Color.Blue;

                    if (i == Maze.Rows - 1 && j == Maze.Columns - 1)
                        b.BackColor = Color.Yellow;

                    if (i == 0 && j == 0)
                        b.BackColor = Color.Green;

                    mazeLayoutPanel.Controls.Add(b, k, l);
                    l++;
                }
                k++;
                l = 0;
            }

            this.Size = mazeLayoutPanel.Size;
            mazeLayoutPanel.ResumeLayout();
            mazeLayoutPanel.Visible = true;

            this.txtCommand.Location = new Point(mazeLayoutPanel.Bounds.Left, mazeLayoutPanel.Bounds.Bottom);
            this.txtCommand.Size = new Size(this.Size.Width / 2, this.txtCommand.Height);
            this.btnGo.Location = new Point(this.txtCommand.Bounds.Right, mazeLayoutPanel.Bounds.Bottom);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCommand.Text))
            {
                Diagnostics.Logger.Instance.Log("Go button clicked");
                _isRunning = true;
                _uiController.ParseCommand(txtCommand.Text);
            }
        }

        private void UpdateGrid(int x, int y, string d)
        {
            // TODO: This causes flickering when the arrow animates
            //mazeLayoutPanel.Visible = false;
            //mazeLayoutPanel.SuspendLayout();

            foreach (object o in this.mazeLayoutPanel.Controls)
            {
                Button b = (Button)o;
                b.Image = null;
            }

            foreach (object o in this.mazeLayoutPanel.Controls)
            {
                if (o is Button)
                {
                    Button b = (Button)o;
                    string temp = String.Format("{0}_{1}", x, y);
                    if (b.Name.Equals(temp))
                    {                        
                        switch(d)
                        {
                            case "R":
                                b.Image = global::MazeNavigatorUI.Properties.Resources.Right;
                                break;
                            case "L":
                                b.Image = global::MazeNavigatorUI.Properties.Resources.Left;
                                break;
                            case "F":
                                b.Image = global::MazeNavigatorUI.Properties.Resources.Forward;
                                break;
                        }

                        // Check if the button at this location is 'Closed'.
                        // If so, warn the user and reset the arrow.
                        if (HasClosedCellBeenReached(b))                            
                            break;

                        if (MazeExitPointHasBeenReached(b))
                            break;

                        break;
                    }
                }
            }

            // TODO: This causes flickering when the arrow animates
            //mazeLayoutPanel.ResumeLayout();
            //mazeLayoutPanel.Visible = true;
        }

        private bool HasClosedCellBeenReached(Button b)
        {
            bool ClosedCellReached = false;

            if (b.BackColor.Equals(Color.Blue))
            {
                Diagnostics.Logger.Instance.Log("Cell cannot be entered.");

                // alert everything to stop
                _isRunning = false;
                MessageBox.Show("Sorry. Try again!", "Out of moves.", MessageBoxButtons.OK);
                CreateMazeVisually();
                _uiController.InitializeControllers();
                ClearCommandText();
                ClosedCellReached = true;
            }
            return ClosedCellReached;
        }

        private bool MazeExitPointHasBeenReached(Button b)
        {
            bool ExitPointReached = false;

            if (b.BackColor.Equals(Color.Yellow))
            {
                // alert everything to stop
                _isRunning = false;
                MessageBox.Show("Well done!", "Success", MessageBoxButtons.OK);
                CreateMazeVisually();
                _uiController.InitializeControllers();
                ClearCommandText();
                ExitPointReached = true;
            }
            return ExitPointReached;
        }

        private void ClearCommandText()
        {
            txtCommand.Clear();
        }
        
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new form for editing the maze details.
            Settings settings = new Settings();
            settings.ShowDialog();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutScreen = new About();
            aboutScreen.ShowDialog();
        }
    }
}