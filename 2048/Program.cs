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
        static int[,] arrMain = new int[4, 4];
        //{
        //        { 0,2,0,2},
        //        { 2,2,0,4},
        //        { 4,8,2,4},
        //        { 2,2,0,0}
        //};
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            ProduceNumber();

            do
            {
                if (ProduceNumber() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                    return;
                }
                Output();
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        Operate();
                        break;
                    case ConsoleKey.UpArrow:
                        TransposeClockwise();
                        Operate();
                        TransposeCounterclockwise();
                        break;
                    case ConsoleKey.DownArrow:
                        TransposeCounterclockwise();
                        Operate();
                        TransposeClockwise();
                        break;
                    case ConsoleKey.LeftArrow:
                        TransposeClockwise();
                        TransposeClockwise();
                        Operate();
                        TransposeClockwise();
                        TransposeClockwise();
                        break;
                }
                Console.Clear();

            }
            while (key.Key != ConsoleKey.Spacebar);




            Console.ReadKey();


        }

        private static int ProduceNumber()
        {
            List<string> zero = new List<string>();//零的个数
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (arrMain[i, j] == 0)
                    {
                        zero.Add(i.ToString() + " " + j.ToString());
                    }
                }
            }
            if (zero.Count == 0)
            {
                return 0;
            }
            int produceIndex = new Random().Next(zero.Count - 1);//随机生成一个2
            arrMain[int.Parse(zero[produceIndex].Split(new string[] { " " }, StringSplitOptions.None)[0]), int.Parse(zero[produceIndex].Split(new string[] { " " }, StringSplitOptions.None)[1])] = 2;
            return 1;
        }
        //顺时针转置
        private static void TransposeClockwise()
        {
            int[,] arrTemp = (int[,])arrMain.Clone();

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    arrMain[i, j] = arrTemp[3 - j, i];
                    // Debug.WriteLine(i.ToString() + " " + j.ToString() + "  " + arrMain[i, j]);
                }
            }

        }
        //逆时针转置
        private static void TransposeCounterclockwise()
        {
            int[,] arrTemp = (int[,])arrMain.Clone();

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    arrMain[i, j] = arrTemp[j, 3 - i];
                    // Debug.WriteLine(i.ToString() + " " + j.ToString() + "  " + arrMain[i, j]);
                }
            }

        }
        //循环输出
        private static void Output()
        {

            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                for (int j = 0; j <= 3; j++)
                {
                    Console.Write("{0,5}", arrMain[i, j]);
                }

            }
            Console.WriteLine();
        }
        //进行一次操作
        private static void Operate()
        {
            Sink();
            Merge();
            Sink();
        }
        //合并相同的项
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
        //将所有的项往一遍倒
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
