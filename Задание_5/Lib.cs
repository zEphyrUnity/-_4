using System;
using System.IO;

namespace TwoDArray
{
    public class Lib
    {
        //Метод вывода в поток консоли двумерного массива
        public static void Show2DArray(int[,] twoD)
        {
            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                {
                    Console.Write($"{twoD[i, j],3} ");
                    if (j == twoD.GetLength(1) - 1)
                        Console.WriteLine("");
                }
        }

        //Метод возвращающий сумму всех элементов массива
        public static int Sum2D(int[,] twoD)
        {
            int sum = 0;

            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                    sum += twoD[i, j];

            return sum;
        }

        //Метод нахождения минимального элемента массива
        public static int MinEl(int[,] twoD)
        {
            int min = 0;
            min = twoD[0, 0];
            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(0); j++)
                    if (min > twoD[i, j])
                        min = twoD[i, j];

            return min;
        }

        //Метод нахождения максимального элемента массива
        public static int MaxEl(int[,] twoD)
        {
            int max = 0;

            max = twoD[0, 0];
            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(0); j++)
                    if (max < twoD[i, j])
                        max = twoD[i, j];

            return max;
        }

        //Метод возвращающий номер максимального элемента массива
        public static int[] MaxNum(int[,] twoD)
        {
            int max = 0;
            int[] maxNum = new int[2];

            max = twoD[0, 0];
            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(0); j++)
                    if (max < twoD[i, j])
                    {
                        max = twoD[i, j];
                        maxNum[0] = i + 1;
                        maxNum[1] = j + 1;
                    }

            return maxNum;
        }
    }
}
