using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static int[,] arrMain = new int[4, 4]{
                { 0,2,0,2},
                { 2,2,0,4},
                { 4,8,2,4},
                { 2,2,0,0} };
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            
            do
            { 
            key = Console.ReadKey();
                if(key.Key==ConsoleKey.RightArrow)
            {
                    
                    Operate();
                }
                Output();
            }
            while (key.Key!=ConsoleKey.Spacebar);
            Console.ReadKey();

            
        }
        private static void Output()
        {
           
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= 3; j++)
                {
                    Console.Write(arrMain[i, j]);
                }
                
            }
            Console.WriteLine();
        }
        private static void Operate()
        {
            Sink();
            Merge();
            Sink();
        }
        private static void Merge()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (arrMain[i, j] == arrMain[i, j + 1] && arrMain[i, j] != 0)
                    {
                        arrMain[i, j] = 0;
                        arrMain[i, j + 1] *= 2;
                    }
                }
            }

        }
        private static void Sink()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 3; j >= 1; j--)
                {
                    if (arrMain[i, j] == 0)
                    {
                        for (int k = j; k >= 1; k--)
                        {
                            int temp = arrMain[i, k - 1];
                            arrMain[i, k - 1] = arrMain[i, k];
                            arrMain[i, k] = temp;
                        }
                    }
                }
            }
        }
    
    }
}
