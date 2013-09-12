using Entities;
using Entities.Maze;
using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
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

        public Form1()
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
            LoadMz();

            foreach (CellContext cellContext in Maze.Cells)
            {
                Button btn = new Button();
                btn.Name = cellContext.XCoordinate + "_" + cellContext.YCoordinate;
                btn.Text = String.Format("({0},{1})", cellContext.XCoordinate, cellContext.YCoordinate);
                this.flowLayoutPanel1.Controls.Add(btn);
                
                //Label lbl = new Label();
                //lbl.BorderStyle = BorderStyle.FixedSingle;
                //lbl.Name = cellContext.XCoordinate + "_" + cellContext.YCoordinate;
                //lbl.Text = String.Format("({0},{1})", cellContext.XCoordinate, cellContext.YCoordinate);
                //this.flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void LoadMz()
        {
            Maze = new Maze(Rows, Columns);
            Maze.InitializeMaze();
            label1.Text = "Grid size: " + Rows + " X " + Columns;
        }
    }
}