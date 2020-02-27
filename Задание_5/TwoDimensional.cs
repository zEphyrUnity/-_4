using System;
using System.IO;
using TwoDArray;

/* Папкин Игорь
 * * а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
 * Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
 * возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер 
 * максимального элемента массива(через параметры, используя модификатор ref или out).
 * ** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
 * ** в) Обработать возможные исключительные ситуации при работе с файлами. */

namespace Task5
{
    class TwoDimensional
    {
        public int[,] twoD;
        public int[,] twoD2;

        string path = @"E:\GEEK UNIVERSITY\GameDev\CSharp_уровень1\Lesson4\Task5\data2.txt";

        //Свойство возвращающее минимальный элемент массива
        public int Min
        {
            get => Lib.MinEl(twoD);
        }

        //Свойство возвращающее максимальный элемент массива
        public int Max
        {
            get => Lib.MaxEl(twoD);
        }

        //Конструктор инициализирующий массив случайными числами
        public TwoDimensional(int row = 10, int col = 10)
        {
            twoD = new int[row, col];
            Random value = new Random();

            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                    twoD[i, j] = value.Next(1, 100);

            twoD2 = new int[row, col];

            TwoDWriter(path, twoD);
            TwoDReader(path, twoD2);
        }

        //Метод записи в файл массива
        public void TwoDWriter(string path, int[,] twoD)
        {
            if (String.IsNullOrEmpty(path)) return;

            StreamWriter sw = new StreamWriter(path);

            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                    sw.WriteLine($"{twoD[i, j]}");
                    
            sw.Flush();
            sw.Close();
        }

        //Метод записи из файла в массив
        public void TwoDReader(string path, int[,] twoD)
        {
            if (String.IsNullOrEmpty(path) || !File.Exists(path)) return;

            StreamReader sr = new StreamReader(path);
            //twoD = new int[row, col];

            for (int i = 0; i < twoD.GetLength(0); i++)
                for (int j = 0; j < twoD.GetLength(1); j++)
                    twoD[i, j] = Int32.Parse(sr.ReadLine());

            sr.Close();
        }

        static void Main()
        {
            int[,] twoD2;

            TwoDimensional Obj1 = new TwoDimensional();

            Lib.Show2DArray(Obj1.twoD);

            //Сумма всех элементов двумерного массива
            Console.WriteLine($"Сумма всех элементов массива: {Lib.Sum2D(Obj1.twoD)}");
            
            //Минимальный элемент массива
            Console.WriteLine($"Минимальный элемент массива: {Obj1.Min}");
            
            //Максимальный элемент массива
            Console.WriteLine($"Максимальный элемент массива: {Obj1.Max}");

            //Номер максимального элемента в двумерном массиве
            int[] maxNum = Lib.MaxNum(Obj1.twoD);
            Console.Write("Номер максимального элемента массива: ");
            foreach (int num in maxNum)
                Console.Write($"{num} ");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
