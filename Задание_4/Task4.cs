using System;
using System.IO;

/* Папкин Игорь
 * Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password. */ 

namespace Task4
{
    // Структура
    struct Account
    {
        public static string login;
        public static string password;
    }

    class Task4
    {
        static string path = @"E:\GEEK UNIVERSITY\GameDev\CSharp_уровень1\Lesson4\Task4\login.txt";

        //Метод чтения из файла
        public static string[] FileReader(string path, int length = 2)
        {
            string[] array = new string[length];

            if (String.IsNullOrEmpty(path) || !File.Exists(path)) return null;

            StreamReader sr = new StreamReader(path);

            for (int i = 0; !sr.EndOfStream; i++)
                array[i] = sr.ReadLine();

            return array;
        }

        //Метод сравнения логина и пароля
        public static bool Verify(string log, string pass)
        {
            if (log == Account.login && pass == Account.password)
                return true;

            return false;
        }

        //Метод login
        public static void UserLogin() 
        {
            string login;
            string password;
            const int attemptNum = 3;
            int attempt = 0;

            while (attempt < attemptNum)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите ваш логин: ");
                login = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите ваш пароль: ");
                password = Console.ReadLine();
                Console.WriteLine();

                if (Verify(login, password))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Логин и пароль введены верно");
                    break;
                }
                else
                {
                    attempt++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Логин и пароль введены не верно, повторите попытку. Попыток осталось: {3 - attempt}");
                }
            }
        }

        static void Main()
        {
            string[] user = new string[2];
            user = FileReader(path);

            Account.login = user[0];
            Account.password = user[1];
         
            UserLogin();

            Console.ReadKey();
        }
    }
}
