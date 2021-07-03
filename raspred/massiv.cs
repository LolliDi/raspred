using System;
using System.Diagnostics;

namespace raspred
{
    class massiv
    {
        public int[,] mas; //массив с данными
        public int r1, r2; //размерности
        public massiv(string s)
        {
            try
            {
                Debug.WriteLine("Начинаем запись в массив");
                string[] chisla = s.Split(" "); //разбиваем строку по пробелам
                r1 = Convert.ToInt32(chisla[0]) + 1;
                r2 = Convert.ToInt32(chisla[1]) + 1;
                int schet = 2;
                mas = new int[r1, r2];
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < r2; j++) //записываем массив строк в массив чисел
                    {
                        if (i == 0 && j == 0)
                            mas[i, j] = 0;
                        else
                        {
                            mas[i, j] = Convert.ToInt32(chisla[schet]);
                            schet++;
                        }
                    }
                }
                Debug.WriteLine("Запись массива завершена!");
                for (int i = 0; i < r1; i++) //выводим массив в дебаг
                {
                    for (int j = 0; j < r2; j++)
                    {
                        Debug.Write($"{mas[i, j]}\t");
                    }
                    Debug.WriteLine("");
                }
            }
            catch
            {
                Console.WriteLine("Неверный форматр введенных данных!");
                Environment.Exit(1);
            }
        }
    }
}
