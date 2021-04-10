
using Rules_Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.PerformanceTest
{

    class Program
    {

        static void Main(string[] args)
        {
           
            string[] Files = System.IO.Directory.GetFiles("Inputs");
            var iterations = 50000;
            int no_inputs = 10;
            int iterator = 1;
            Stopwatch stopwatch;
            Console.WriteLine("Iterations: {0}", iterations);
            foreach (string sFile in Files)
            {
                if (iterator != no_inputs)
                {

                     
                    string fileCont = System.IO.File.ReadAllText(sFile);

                    var size = Math.Sqrt(fileCont.Length);
                    Console.WriteLine(size);
                    var grid = new LifeGrid((int)size, (int)size);
                    Console.WriteLine("Grid size: {0} x {0}", (int)size, (int)size);
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                        {
                            char bits = fileCont[i + j];
                            if (bits.Equals('0'))
                            {
                                grid.CurrentState[i, j] = CellState.Dead;
                            }
                            else
                            {
                                grid.CurrentState[i, j] = CellState.Alive;
                            }


                        }

                    stopwatch = Stopwatch.StartNew();

                    for (int i = 0; i < iterations; i++)
                    {
                        grid.UpdateState();
                    }
                    Console.WriteLine("Nested for: {0}ms", stopwatch.ElapsedMilliseconds);
                    stopwatch.Stop();
                    iterator++;
                }
                else {
                    Console.ReadLine();
                    Environment.Exit(0); }
               
            }








           

            

            
            
            for (int i = 0; i < iterations; i++)
                //grid.UpdateState();
           





            Console.ReadLine();
        }
    }
    }

    
