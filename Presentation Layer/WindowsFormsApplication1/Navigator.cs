using Controllers;
using Entities;
using System;
using System.Text;
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

        private StringBuilder stringBuilder;
        public StringBuilder StringBuilder
        {
            get { return stringBuilder; }
            set { stringBuilder = value; }
        }

        public NavigatorUI()
        {
            InitializeComponent();            

            Random = new Random();
            StringBuilder = new StringBuilder();

            Rows = Random.Next(3, MAX_ROWS);
            Columns = Random.Next(3, MAX_COLUMNS);

            this.ClientSize = new System.Drawing.Size(rows*100, columns*100);
            flowLayoutPanel1.Size = new System.Drawing.Size(this.Height-10, this.Width-10);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // UI Controller interacts with the Maze Controller
            MazeController mazeController = new MazeController(MAX_ROWS, MAX_COLUMNS);
            Maze = mazeController.Maze;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}