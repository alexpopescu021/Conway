
using Rules_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid(25, 25);
            grid.Randomize();

            ShowGrid(grid.CurrentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentState.GetUpperBound(1) + 1;  // fara +1 ia height-ul, cu +1 verifica width, ce ne trebuie

            var output = new StringBuilder();   // Instead of directly writing to the console, we add the characters to the StringBuilder. Then at the very end, we call Console.Write one time.
                                                // String is immutable, stringBuilder can be modified
            foreach (var state in currentState)
            {
                output.Append(state == CellState.Alive ? "O" : "·");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.Write(output.ToString());
        }
    }
}
