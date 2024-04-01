using System;
using System.IO;

namespace _MDK_0104_Practice_7_
{
    internal class Program
    {
        static void Main()
        {
            double sum = 0;
            int count = 0;

            try
            { 
                BinaryWriter F = new BinaryWriter(new FileStream("weather.txt", FileMode.OpenOrCreate));
                Random random = new Random();
                
                for (int i = 0; i < 12; i++)
                {
                    double valueWeather = i >= 2 && i <= 8 ? random.NextDouble() * (-10 - 10) + 10 : random.NextDouble() * (40 - 20) + 20;
                    F.Write(valueWeather);
                }
                F.Close();
                
                FileStream f = new FileStream("weather.txt", FileMode.Open);
                BinaryReader read = new BinaryReader(f);

                try
                {
                    while (true)
                    {
                        double value = read.ReadDouble();
                        sum += value;
                        count++;
                    }
                }
                catch (EndOfStreamException) { }
                double averageValueWeather = sum / count;
                read.Close();
                f.Close();

                
                F = new BinaryWriter(new FileStream("weather.txt", FileMode.Append));
                F.Write(averageValueWeather);
                F.Close();

                Console.WriteLine("Среднегодовая температура = {0:f1}", averageValueWeather);

                read = new BinaryReader(new FileStream("weather.txt", FileMode.Open));
                for (int i = 0; i < 12; i++)
                {
                    double output = read.ReadDouble();
                    Console.Write("| {0:f1} |",output);
                }
                
                averageValueWeather = read.ReadDouble();
                Console.WriteLine();
                Console.WriteLine($"Среднегодовая температура в файле: {averageValueWeather} ");

                read.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }
        }
    }
}
