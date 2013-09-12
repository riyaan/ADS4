using Entities;
using Entities.Cell;
using Entities.Maze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrowContext 

            //ArrowContext c = new ArrowContext(new ConcreteStateNorth());
            //c.MoveNorth();
            //c.MoveSouth();
            //c.MoveSouth();
            //c.MoveNorth();
            //c.MoveSouth();

            ///*
            // * NORTH FACING
            // * NO EFFECT. MOVING.
            // * SOUTH FACING.
            // * NO EFFECT. MOVING.
            // */

            //Console.ReadLine();

            #endregion ArrowContext

            #region CellContext

            //CellContext context = new CellContext(new ConcreteStateOpen());
            //context.Occupy();
            //context.Occupy(); // Cell is already occupied.
            //context.UnOccupy();
            //context.Occupy();

            #endregion CellContext

            #region ArrowController

            //ArrowController controller = ArrowController.getInstance();
            //controller.InitializeGrid();
            //controller.InitializeArrow();
            //controller.Command(COMMAND.F1);

            #endregion ArrowController

            #region Factory Method Pattern testing

            //CellProductBase openProduct = CellFactory.MakeCell(CELL_TYPE.OPEN);
            //CellProductBase closedProduct = CellFactory.MakeCell(CELL_TYPE.CLOSED);

            //openProduct.Display();
            //closedProduct.Display();

            #endregion Factory Method Pattern testing

            #region Mz Testing using Strategy

            Maze maze = new Maze(3, 3);
            maze.InitializeMaze();
            Console.WriteLine("Maze has been initialized");

            //int cellNumber = 1;
            //foreach (CellContext c in maze.Cells)
            //{
            //Console.WriteLine(String.Format("Cell number {0}__ X: {1} __ Y: {2}", cellNumber, c.XCoordinate, c.YCoordinate));
            bool done = false;
            //while (!LastCellReached)
            //{
            //for (int i = 0; i < maze.Rows; i++)
            //{
            //    for (int j = 0; j < maze.Columns; j++)
            //    {
            //        Console.Write("|_|");
            //    }
            //    Console.WriteLine();
            //}
            //}
            //cellNumber++;
            //}            
            Console.WriteLine();
            Console.WriteLine("Maze search starting");
            Random rnd = new Random();
            //SearchList(maze, 0, 0, 0, 0, done, rnd);


            Console.WriteLine();
            Console.WriteLine("Done searching maze");
            foreach (CellContext c in maze.Cells)
            {
                Console.WriteLine(String.Format("Cell X, Y: {0},{1}__State: {2}", c.XCoordinate, c.YCoordinate, c.CurrentState.ToString()));
            }

            for(int i=0; i<maze.Cells.Count; i++)
            {
                //rnd.Next(
            }
            
            #endregion Mz Testing

            #region Mz Testing using FactoryMethod

            //Maze m = new Maze(3, 3);
            //m.InitializeMaze();
            //foreach (CellProductBase cell in m.Cells)
            //{                
            //    cell.Display();
            //}

            #endregion

        }

        //public static void SearchList(Maze m, int previousRow,  int previousColumn, int currentRow, int currentColumn, bool done, Random rnd)
        //{
        //    if (done)
        //        return;
        //    else
        //    {
        //        // find the cell with this coordinates
        //        foreach (CellContext c in m.Cells)
        //        {
        //            if (c.XCoordinate == currentRow && c.YCoordinate == currentColumn)
        //            {
        //                if (c.Occupy())
        //                    break;
        //            }

        //            if(currentRow >= m.Rows-1 && currentColumn >= m.Columns-1)
        //            {
        //                if (c.Occupy())
        //                {
        //                    done = true;
        //                    break;
        //                }
        //            }
        //        }

        //        previousColumn = currentColumn;
        //        previousRow = currentRow;

        //        if (currentColumn == 0 && currentRow == 0)
        //        {
        //            currentRow+=2;
        //            currentColumn+=2;
        //        }

        //        // generate next random column/row
        //        int randomRow = rnd.Next(currentRow);
        //        int randomColumn = rnd.Next(currentColumn);

        //        while((randomRow+randomColumn) <= (previousRow+previousColumn))
        //        {
        //            randomRow = rnd.Next(currentRow++);
        //            randomColumn = rnd.Next(currentColumn++);
        //        }

        //        SearchList(m, previousRow, previousColumn, randomRow, randomColumn, done, rnd);
        //    }
        //}
    }
}