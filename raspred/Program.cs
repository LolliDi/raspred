using System;
using System.Diagnostics;
using System.IO;

namespace raspred
{
    public class Program
    {
        static void Main(string[] args)
        {
            string link = Environment.CurrentDirectory; //ищем путь к exe
            link = link.Replace(@"raspred\bin\Debug\netcoreapp3.1", ""); //убираем ненужное
            massiv a = new massiv(read(link));
            write(link, reshenie(a));

        }
        static string read(string link) //метод чтения
        {
            Console.WriteLine("Считываем данные...");
            string stroka_dannih = "";
            try
            {
                using (StreamReader sr = new StreamReader(link + "input.csv"))
                {
                    stroka_dannih = sr.ReadToEnd();
                }
                Trace.WriteLine("Считал строку: " + stroka_dannih);
            }
            catch
            {
                Console.WriteLine("Ошибка считывания файла!");
                Environment.Exit(1);
            }
            return stroka_dannih;
        }
        public static string reshenie(massiv a) //решение
        {
            Console.WriteLine("Решение транспортной задачи методом Северо-Западного угла");
            int F = 0;
            string otvet = "";
            for (int i = 1; i < a.r1; i++)
            {
                for (int j = 1; j < a.r2; j++) //перебор массива
                {
                    if (a.mas[0, j] != 0 && a.mas[i, 0] != 0)
                    {
                        if (a.mas[0, j] >= a.mas[i, 0]) //если спрос больше предложения, то вычитаем из спроса предложение и записываем поставку
                        {
                            a.mas[0, j] -= a.mas[i, 0];
                            F += a.mas[i, 0] * a.mas[i, j];
                            otvet += $"От {i}-го поставщика к {j}-му потребителю едет {a.mas[i, 0]} ед. товара по цене {a.mas[i, j]}у.д.е. за шт.\n";
                            a.mas[i, 0] = 0;
                        }
                        else //наоборот 
                        {
                            a.mas[i, 0] -= a.mas[0, j];
                            F += a.mas[0, j] * a.mas[i, j];
                            otvet += $"От {i}-го поставщика к {j}-му потребителю едет {a.mas[0, j]} ед. товара по цене {a.mas[i, j]}у.д.е. за шт.\n";
                            a.mas[0, j] = 0;
                        }
                    }
                }
            }
            a.pokazhi();
            otvet += "Ответ: F = " + F + "у.д.е.";
            Trace.WriteLine(otvet);
            Console.WriteLine("Решение завершено!");
            return otvet;
        }
        static void write(string link, string s) //запись ответа в файл
        {
            Console.WriteLine("Записываем ответ в файл!");
            try
            {
                using (StreamWriter sw = new StreamWriter(link + "output.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                }

            }
            catch
            {
                Console.WriteLine("Не удалось записать данные!! Проверьте ссылку!");
                Environment.Exit(1);
            }
            try //открываем файл
            {
                Console.WriteLine("Запись завершена! Открываем файл с ответом...");
                Process otkr = new Process();
                otkr.StartInfo.FileName = "notepad.exe";
                otkr.StartInfo.Arguments = link + "output.txt";
                otkr.Start();
            }
            catch
            {
                Console.WriteLine("Не удалось открыть файл!");
            }
        }
    }
}
