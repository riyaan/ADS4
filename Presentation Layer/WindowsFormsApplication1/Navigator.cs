using Controllers;
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

        public NavigatorUI()
        {
            InitializeComponent();            

            //Random = new Random((int)DateTime.Now.Ticks);
            //Rows = Random.Next(3, MAX_ROWS);
            //Columns = Random.Next(3, MAX_COLUMNS);

            //this.ClientSize = new System.Drawing.Size(rows*100, columns*100);
            mazeLayoutPanel.Size = new System.Drawing.Size(this.Height, this.Width);

            backGroundWorker1 = new BackgroundWorker();
            backGroundWorker1.DoWork += backGroundWorker1_DoWork;
            backGroundWorker1.RunWorkerCompleted += backGroundWorker1_RunWorkerCompleted; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mazeLayoutPanel.Controls.Clear();
            backGroundWorker1.RunWorkerAsync();           
        }

        void backGroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CreateMazeVisually();
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
            UIController uiController = new UIController();
            Maze = uiController.GenerateNewMaze(Rows, Columns);
        }

        private void CreateMazeVisually()
        {
            // TODO: Create this on a seperate thread
            mazeLayoutPanel.RowCount = Maze.Rows;            
            mazeLayoutPanel.ColumnCount = Maze.Columns;

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
        }

        private void mazeLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            //this.ClientSize = new Size(mazeLayoutPanel.Size.Width + 50, mazeLayoutPanel.Size.Height + 50);
            //this.SetClientSizeCore(mazeLayoutPanel.Size.Width, mazeLayoutPanel.Size.Height);
            //this.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}