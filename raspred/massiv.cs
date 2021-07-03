using System;
using System.Diagnostics;

namespace raspred
{
    public class massiv
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
                        if (i == 0 && j == 0) //перекретье между спросом и предложением
                            mas[i, j] = 0;
                        else
                        {
                            mas[i, j] = Convert.ToInt32(chisla[schet]);
                            schet++;
                        }
                    }
                }
                Console.WriteLine("Запись массива завершена!");
                pokazhi();
            }
            catch
            {
                Console.WriteLine("Неверный формат введенных данных!\n Формат должен быть следующим(через пробел только цифры):\n" +
                    " [количество строк] [количество столбцов] [перечисление потребностей] [предложение] [[перечисление стоимостей отправки] [предложение] [перечисление стоимостей отправки]...]");
                Environment.Exit(1);
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < r1; i++) // проверяем равен ли спрос предложению
            {
                for (int j = 0; j < r2; j++)
                {
                    if (i == 0)
                        sum1 += mas[i, j];
                    if (j == 0)
                        sum2 += mas[i, j];
                }
            }
            if (sum1 != sum2) //если спрос не равен предложению - завершаем программу
            {
                Debug.WriteLine("Спрос клиентов не равен предложению!");
                Console.WriteLine("Программа не может продолжить работу, т.к. не выполнено условие равенства спроса предложению!");
                Environment.Exit(1);
            }
            else
            {
                Debug.WriteLine("Равенство подтвердилось");
            }
        }
        public void pokazhi() //выводим массив в дебаг консоль
        {
            
            Debug.WriteLine("Массив:");
            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < r2; j++)
                {
                    Debug.Write($"{mas[i, j]}\t");
                }
                Debug.WriteLine("");
            }
        }
    }
}
