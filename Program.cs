using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static bool IsPalindrom(string text)
        {
            //удаляем пробелы
            var s = text.Replace(" ", string.Empty);
            //приводим в нижний регистр
            s = s.ToLower();
            //индекс последнего символа
            int lastIndex = s.Length - 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
                //если символы не одинаковые, возвращаем false
                if (s[i] != s[lastIndex - i])
                {
                    return false;
                }
            }

            return true;
        }

        //строка со счетом предыдущих элементов
        static void generateUnitCountRow(int n)
        {
            //Создаю вектор для хранения строк
            

            //Инициализирую первый элемент
            string [] resultVect = new string[n];
            resultVect[0] = "1";

            //формирую строки
            for (Int32 i = 1; i < n; ++i) {

                //вытягиваю из вектора предыдущую строку
                string previous = resultVect[i - 1];

                //создаю текущую строку
                string current = "";

                //формирую текущую строку(добавляю следующую цифру и так пока не конец строки)
                for (Int32 j=0; j < previous.Length; ++j) {
                    int count = 1;
                    //пока не закончилась строка и текущая единица продолжаю увеличивать счетчик
                    while (j + 1 < previous.Length && previous[j] == previous[j + 1])
                    {
                        ++count;
                        ++j;
                    }


                    current += count.ToString() + previous[j];
                }

                resultVect[i] = current;
            }

            //отображаю результаты
            foreach (var element in resultVect)
                Console.WriteLine(element);


        }


        static void Main(string[] args)
        {
            //    Console.Write("Введите высоту треугольника ->");
            //    int height = int.Parse(Console.ReadLine());

            //    for (int i = 0; i < height; i++)
            //    {
            //        for (int j = 0; j < height - i - 1; j++)
            //        {
            //            Console.Write(" ");
            //        }

            //        for (int j = 0; j < 2 * i + 1; j++)
            //        {
            //            Console.Write("*");
            //        }
            //        Console.WriteLine();
            //    }

            ////1.Дана строка символов. Необходимо проверить, является ли эта строка палиндромом. Примеры палиндромов:

            string userString;

            Console.Write("Введите строку -> ");
            userString = Console.ReadLine();

            if (IsPalindrom(userString))
            {
                Console.WriteLine("Это палиндром!");
            }
            else
            {
                Console.WriteLine("Это не палиндром!");
            }



            ///    23.	Дана последовательность:
            ////            1,
            ////           11, предыдущий элемент : 1 - единица
            ////           21, предыдущий элемент : 2 - единицы
            ////         1211, предыдущий элемент : 1 - двойка 1 - единица
            ////       111221, предыдущий элемент : 1 - единица 1 - двойка 2 - единицы
            ////       312211, предыдущий элемент : 3 - единицы 2 - двойки 1 - единица
            ////     13112221, предыдущий элемент : 1 - тройка 1 - единица 2 - двойки 2 - единицы
            ////   1113213211, следующее число
            ////… Ввести число N.Показать N - ный по счёту элемент последовательности.
            generateUnitCountRow(10);

            // 11 змейка заполнение массива
            const int ROW = 5, COL = 4;
            int [,] arr2D = new int[ROW,COL];
            int counter = 0;

            for (int row = 0; row < ROW; ++row)
            {
                for (int col = 0; col < COL; ++col)
                {
                    ++counter;
                    if (row % 2 == 0)
                    {
                        arr2D[row,col] = counter;
                    }
                    else
                    {
                        arr2D[row,COL - col - 1] = counter;
                    }
                }
            }

            // вывод
            for (int row = 0; row < ROW; ++row)
            {
                for (int col = 0; col < COL; ++col)
                {
                    if (arr2D[row,col] % 10 == arr2D[row,col])
                    {
                        Console.Write("   ");
                    }
                    else if (arr2D[row,col] % 100 == arr2D[row,col])
                    {
                        Console.Write("  ");
                    }
                    else if (arr2D[row,col] % 1000 == arr2D[row,col])
                    {
                        Console.Write(" ");
                    }
                    Console.Write( arr2D[row,col]);
                }
                Console.WriteLine();
            }
        }


    }
}
