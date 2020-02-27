using System;
using System.IO;

namespace Lib
{
    public static class ArrayLib
    {
        //Метод вывода массива в консоль
        public static void ShowArray(int[] array)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"[{i,2}]: {array[i]} ");

            Console.WriteLine();
        }

        //Метод подсчета количества пар элементов массива, в которых только одно число делится на 3
        public static int Pair(int[] array)
        {
            int pairCount = 0;

            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] % 3 == 0 ^ array[i + 1] % 3 == 0)
                    pairCount++;

            return pairCount;
        }

        //Метод записи массива в файл
        public static void FileWriter(int[] array, string path)
        {
            if (String.IsNullOrEmpty(path)) return;

            StreamWriter sw = new StreamWriter(path);

            for (int i = 0; i < array.Length; i++)
                sw.WriteLine(array[i]);

            sw.Flush();
            sw.Close();

            Console.WriteLine($"Файл {path} создан, массив записан");
        }

        //Метод чтения массива из файла
        public static int[] FileReader(string path, int length)
        {
            int[] array = new int[length];

            if (String.IsNullOrEmpty(path) || !File.Exists(path)) return null;

            StreamReader sr = new StreamReader(path);

            for (int i = 0; !sr.EndOfStream; i++)
                array[i] = Int32.Parse(sr.ReadLine());

            return array;

            sr.Close();
        }

        //Метод расчета суммы элементов массива
        public static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            return sum;
        }

        //Метод инверсии элементов массива
        public static int[] Inversion(int[] array)
        {
            int[] invertedArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                invertedArray[i] = -array[i];

            return invertedArray;
        }

        //Метод подсчета количества максимальных элементов массива
        public static int MaxCounter(int[] array)
        {
            int maxCount = 0;
            int maxValue;

            maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
                if (maxValue < array[i])
                    maxValue = array[i];

            for (int i = 0; i < array.Length; i++)
                if (array[i] == maxValue)
                    maxCount++;

            return maxCount;
        }

        //Метод умножения значений массива на заданое число
        public static int[] Multi(int[] array, int multiplicator)
        {
            int[] multiArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                multiArray[i] = array[i] * multiplicator;

            return multiArray;
        }

        //Метод инициализации массива типа integer
        public static int[] ArrayCreator(int num = 10)
        {
            Random value = new Random();
            int[] array = new int[num];

            for (int i = 0; i < array.Length; i++)
                array[i] = value.Next(-10000, 10000);

            return array;
        }
    }
}
