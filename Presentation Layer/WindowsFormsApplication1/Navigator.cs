using Controllers;
using Diagnostics;
using Entities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
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
            UpdateGrid(0, 0, "U");
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
            _uiController = new UIController();
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

            //string output = String.Empty;
            for (int i = Maze.Rows - 1; i >= 0; i--)
            {
                for (int j = Maze.Columns - 1; j >= 0; j--)
                {
                    Button b = new Button
                    {
                        Name = Maze.Grid[i, j].XCoordinate + "_" + Maze.Grid[i, j].YCoordinate,
                        Size = new Size(18, 23)
                    };

                    if (Maze.Grid[i, j].CellState == CELL_STATE.OPEN)
                    {
                        b.BackColor = Color.Blue;
                        //output += "|O|";
                    }
                    else
                    {                        
                        //output += "|X|";
                    }
                    
                    mazeLayoutPanel.Controls.Add(b, j, i);
                }
                //output += System.Environment.NewLine;
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

            // Update the grid
            UpdateGrid(arrowX, arrowY, direction);
        }

        private void UpdateGrid(int x, int y, string d)
        {
            foreach (object o in this.mazeLayoutPanel.Controls)
            {
                Button b = (Button)o;
                b.Text = String.Empty;
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
                            case "L":
                                b.Text = "--";
                                break;
                            case "U":
                                b.Text = "|";
                                break;
                        }
                        break;
                    }
                }
            }
        }
    }
}