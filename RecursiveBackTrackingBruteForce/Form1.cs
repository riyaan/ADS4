using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursiveBackTrackingBruteForce
{
    public partial class Form1 : Form
    {
        const int ROW = 3;
        const int COLUMN = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            Maze m = new Maze(ROW, COLUMN);
            m.InitializeMaze();

            m.CarvePassage();
            PrintLabels(m);
        }

        private void PrintLabels(Maze m)
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.RowCount = ROW;
            panel.ColumnCount = COLUMN;
            panel.AutoSize = true;

            this.Controls.Add(panel);

            int c = 0;
            for (int i = 0; i < m.Grid.Length; i++)
            {
                for (int j = 0; j < ROW; j++)
                {                    
                    for (int k = 0; k < COLUMN; k++)
                    {                        
                        Label lbl = new Label();
                        lbl.BorderStyle = BorderStyle.Fixed3D;
                        lbl.Text = m.Cells[c].XCoordinate + "," + m.Cells[c].YCoordinate;
                        lbl.Margin = new Padding(0, 0, 0, 0);

                        //foreach (Wall w in m.Cells[c].Walls)
                        //{
                        //    //if (w.Direction == WallDirection.NORTH && w.State == WallState.UP)
                        //    //{
                        //    //}
                        //}

                        if (m.Cells[c].State == CellState.VISITED)
                        {
                            lbl.BackColor = Color.Red;                            
                        }
                        else
                        {
                            lbl.BackColor = Color.Green;
                        }

                        panel.Controls.Add(lbl, k, j);
                        c++;

                        if (c >= m.Cells.Count)
                            break;
                    }

                    if (c >= m.Cells.Count)
                        break;
                }
                if (c >= m.Cells.Count)
                    break;
            }
        }

        private void PrintGrid(Maze m)
        {
            int c = 0;
            for (int i = 0; i < m.Grid.Length; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    for (int k = 0; k < COLUMN; k++)
                    {
                        if (m.Cells[c].State == CellState.VISITED)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("O");
                        }
                        c++;

                        if (c >= m.Cells.Count)
                            break;
                    }
                    Console.WriteLine();

                    if (c >= m.Cells.Count)
                        break;
                }
                if (c >= m.Cells.Count)
                    break;
            }
        }
    }
}
