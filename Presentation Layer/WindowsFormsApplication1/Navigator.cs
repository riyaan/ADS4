using Controllers;
using Entities;
using SharedEvents;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MazeNavigatorUI
{
    public partial class NavigatorUI : Form
    {
        const int MAX_ROWS = 10;
        const int MAX_COLUMNS = 10;

        private int rows;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int columns;
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private Random random;
        public Random Random
        {
            get { return random; }
            set { random = value; }
        }

        private Maze maze;
        public Maze Maze
        {
            get { return maze; }
            set { maze = value; }
        }

        private BackgroundWorker backGroundWorker1;

        private UIController _uiController;

        public NavigatorUI()
        {
            InitializeComponent();

            mazeLayoutPanel.Size = new System.Drawing.Size(this.Height, this.Width);

            backGroundWorker1 = new BackgroundWorker();
            backGroundWorker1.DoWork += backGroundWorker1_DoWork;
            backGroundWorker1.RunWorkerCompleted += backGroundWorker1_RunWorkerCompleted;

            _uiController = new UIController();
            _uiController.ArrowChanged += _uiController_ArrowChanged;
        }

        void _uiController_ArrowChanged(object sender, ArrowChangedEventArgs e)
        {
            // TODO: Update the buttons
            Diagnostics.Logger.Instance.Log("Handling the arrow changed event.");
            ArrowContext ac = e.Arrow;
            Diagnostics.Logger.Instance.Log("Current State: " + ac.CurrentState.ToString());
            Diagnostics.Logger.Instance.Log(String.Format("X:{0} Y:{1}", ac.X, ac.Y));

            // Clear all the button images
            string direction = String.Empty;
            if(ac.CurrentState.ToString().ToUpper().Contains("RIGHT"))
                direction = "R";
            else if(ac.CurrentState.ToString().ToUpper().Contains("LEFT"))
                direction = "L";
            else if(ac.CurrentState.ToString().ToUpper().Contains("FORWARD"))
                direction = "F";

            UpdateGrid(ac.X, ac.Y, direction);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            backGroundWorker1.RunWorkerAsync();           
        }

        void backGroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CreateMazeVisually();

            // Thethe ArrowController should create the intial location of this arrow
            
            // the Arrow Controller should communicate to the UI Controller to display the arrow correctly
            // in the grid.
            UpdateGrid(0, 0, "F");
        }

        void backGroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GenerateMaze();
        }

        private void GenerateMaze()
        {
            Rows = Int32.Parse(this.txtRows.Text);
            Columns = Int32.Parse(this.txtColumns.Text);

            // UI Controller interacts with the Maze Controller            
            Maze = _uiController.GenerateNewMaze(Rows, Columns);
        }

        private void CreateMazeVisually()
        {
            // TODO: Create this on a seperate thread
            mazeLayoutPanel.Visible = false;
            mazeLayoutPanel.Controls.Clear();
            mazeLayoutPanel.RowCount = Maze.Rows;            
            mazeLayoutPanel.ColumnCount = Maze.Columns;

            mazeLayoutPanel.SuspendLayout();

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

                    if(i==Maze.Rows-1 && j==Maze.Columns-1)
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
            this.btnGo.Location = new Point(this.txtCommand.Bounds.Right, mazeLayoutPanel.Bounds.Bottom);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Process the command
            int arrowX, arrowY;
            string direction;
            _uiController.ParseCommand(txtCommand.Text, out arrowX, out arrowY, out direction);
        }

        private void UpdateGrid(int x, int y, string d)
        {
            Diagnostics.Logger.Instance.Log("Updating the buttons");

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
                                b.Invalidate();
                                break;
                            case "L":
                                b.Image = global::MazeNavigatorUI.Properties.Resources.Left;
                                b.Invalidate();
                                break;
                            case "F":
                                b.Image = global::MazeNavigatorUI.Properties.Resources.Forward;
                                b.Invalidate();
                                break;
                        }
                        break;
                    }
                }
            }
        }        
    }
}