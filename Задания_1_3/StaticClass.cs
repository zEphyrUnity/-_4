using System;
using System.Collections.Generic;
using Lib;

/* Папкин Игорь
 * 1) Дан целочисленный  массив из 20 элементов. Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
 * Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, 
 * в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
 * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
 * 
 * 2) Реализуйте задачу 1 в виде статического класса StaticClass;
 * а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
 * б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
 * в)** Добавьте обработку ситуации отсутствия файла на диске.
 * 
 * 3 а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного 
 * размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает 
 * сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  
 * метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
 * б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
 * е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)*/

namespace Task1_3
{
    class StaticClass
    {
        int[] basicArray;
        int[] basicArray2;

        Dictionary<int, int> frequency;

        //свойство Sum, которое возвращает сумму элементов массива
        public int Sum
        {
            get => ArrayLib.SumArray(basicArray);
        }

        //свойство MaxCount, возвращающее количество максимальных элементов.
        public int MaxCount
        {
            get => ArrayLib.MaxCounter(basicArray2);
        }

        //Конструктор массива с шагом
        public StaticClass(int arraySize = 20, int startValue = 0, int step = 10)
        {
            basicArray = new int[arraySize];

            basicArray[0] = startValue;
            for (int i = 1; i < basicArray.Length; i++)
                basicArray[i] += basicArray[i - 1] + step;
        }

        //Метод для работы с коллекцией Dictionary и подсчета частоты вхождения элементов массива
        public static Dictionary<int, int> Frequency(int[] array)
        {
            Dictionary<int, int> collect = new Dictionary<int, int>();
            int counter;
            
            for(int i = 0; i < array.Length; i++)
            {
                counter = 1;

                for(int j = i + 1; j < array.Length; j++)
                    if(array[i] == array[j])
                        counter++;

                if (!collect.ContainsKey(array[i]))
                    collect.Add(array[i], counter);
            }

            return collect;
        }

        static void Main()
        {
            const int arraySize = 20;
            string path         = @"E:\GEEK UNIVERSITY\GameDev\CSharp_уровень1\Lesson4\Task1\Array.txt";

            //Заполнить случайными числами
            var arr1 = ArrayLib.ArrayCreator(arraySize);

            Console.WriteLine("Вновь созданный массив arr1:");
            ArrayLib.ShowArray(arr1);

            //С помощью метода Pair подсчитываю количество пар элементов массива, в которых только одно число делится на 3
            Console.WriteLine($"Количество пар элементов массива, в которых только одно число делится на 3: {ArrayLib.Pair(arr1)} \n");

            //Запись в файл массив чисел
            ArrayLib.FileWriter(arr1, path);

            //Cтатический метод для считывания массива из текстового файла
            //int[] arr2 = new int[arraySize];
            var arr2 = ArrayLib.FileReader(path, arraySize);
            Console.WriteLine("Массив введеный из потока файла Array.txt");
            ArrayLib.ShowArray(arr2);

            //конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
            StaticClass Sc1 = new StaticClass(startValue : 100, step : 100, arraySize : 10);
            Console.WriteLine("Массив с заданым шагом:");
            ArrayLib.ShowArray(Sc1.basicArray);

            //свойство Sum, которое возвращает сумму элементов массива
            Console.WriteLine($"Сумма элементов массива с заданым шагом: {Sc1.Sum} \n");

            //метод Inversion, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений)
            var arr3 = ArrayLib.Inversion(arr1);
            Console.WriteLine("Инвертированый массив arr1:");
            ArrayLib.ShowArray(arr3);

            //метод Multi, умножающий каждый элемент массива на определённое число
            var arr4 = ArrayLib.Multi(arr1, 2);
            Console.WriteLine("Массив arr1 умноженый на заданное число:");
            ArrayLib.ShowArray(arr4);

            //свойство MaxCount, возвращающее количество максимальных элементов
            Sc1.basicArray2 = arr2;
            Console.WriteLine($"Вхождение максимальных элементов в массив: {Sc1.MaxCount}");
            Console.WriteLine();

            //Работа с коллекцией
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            Sc1.frequency = Frequency(arr2);

            foreach (KeyValuePair<int, int> kvp in Sc1.frequency)
                Console.WriteLine($"Элемент массива: {kvp.Key} имеет вхождений: {kvp.Value}");

            Console.ReadKey();
        }
    }
}
