using System;
using System.IO;
using System.Diagnostics;

namespace raspred
{
    class Program
    {
        static void Main(string[] args)
        {
            massiv a = new massiv(read());

        }
        static string read()
        {
            Console.WriteLine("Считываем данные...");
            string link = @"C:\Users\290ro\Desktop\ekz\raspred\";
            string stroka_dannih="";
            try
            {
                using (StreamReader sr = new StreamReader(link + "input.csv"))
                {
                    stroka_dannih = sr.ReadToEnd();
                }
                Debug.WriteLine("Считал строку: " + stroka_dannih);
            }
            catch
            {
                Console.WriteLine("Ошибка считывания файла!");
                Environment.Exit(1);
            }
            return stroka_dannih;
        }
        static int reshenie (massiv a)
        {
            Console.WriteLine("Решение транспортной задачи методом Северо-Западного угла");
            int F = 0;
            for(int i = 0; i<a.r1;i++)
            {
                for(int j = 0; j<a.r2;j++)
                {
                    if(a.mas[0,j]!=0&&a.mas[i,0]!=0)
                    {
                        if (a.mas[0, j] >= a.mas[i, 0]) //если спрос больше предложения, то вычитаем из спроса предложение и записываем поставку
                        {
                            a.mas[0, j] -= a.mas[i, 0];
                            F += a.mas[i, 0] * a.mas[i, j];
                            Debug.WriteLine($"Из {i} в {j} едет {a.mas[i, 0]} по {a.mas[i, j]}");
                            a.mas[i, 0] = 0;
                        }
                        else //наоборот 
                        {
                            a.mas[i, 0] -= a.mas[0, j];
                            F += a.mas[0, j] * a.mas[i, j];
                            Debug.WriteLine($"Из {i} в {j} едет {a.mas[0, j]} по {a.mas[i, j]}");
                            a.mas[0, j] = 0;
                        }
                    }
                }
            }
            a.pokazhi();
            Debug.WriteLine("F = " + F);
            return F;
        }
    }
}
