using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveBacktracking
{
    class Mz
    {
        const int N = 1;
        const int S = 2;
        const int E = 4;
        const int W = 8;

        Hashtable DX;
        Hashtable DY;
        Hashtable OPPOSITE;

        public Mz()
        {             
            DX = new Hashtable();
            DX["E"] = 1;
            DX["W"] = -1;
            DX["N"] = 0;
            DX["S"] = 0;

            DY = new Hashtable();
            DY["E"] = 0;
            DY["W"] = 0;
            DY["N"] = -1;
            DY["S"] = 1;

            OPPOSITE = new Hashtable();
            OPPOSITE["E"] = W;
            OPPOSITE["W"] = E;
            OPPOSITE["N"] = S;
            OPPOSITE["S"] = N;
        }

        public void carvePassage(int cx, int cy, ref int[,] grid)
        {
            List<string> directions = new List<string>(4);
            directions.Add("N");
            directions.Add("S");
            directions.Add("W");
            directions.Add("E");

            directions.Sort();

            foreach (string direction in directions)
            {                
                int nx = cx + (int)DX[direction];
                int ny = cy + (int)DY[direction];

                //if ny.between?(0, grid.length-1) && 
                //nx.between?(0, grid[ny].length-1) && grid[ny][nx] == 0
                if (
                    (ny >= 0 && ny < grid.GetLength(0)-1) && 
                    (nx >= 0 && nx < grid.GetLength(1)-1) && 
                    (grid[ny, nx] == 0)
                   )
                {
                    grid[cy, cx] |= (int)DX[direction];
                    grid[ny, nx] |= (int)OPPOSITE[direction];

                    carvePassage(nx, ny, ref grid);
                }
            }
        }
    }
}
