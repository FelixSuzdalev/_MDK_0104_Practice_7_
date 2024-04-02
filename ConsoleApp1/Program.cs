using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            // назначение источника данных для ввода, вместо клавиатуры
            StreamReader inFile = new StreamReader("salary.txt");
            Console.SetIn(inFile);
            // назначение приемника данных, вместо экрана
            StreamWriter outFile = new StreamWriter("jounal.txt");
            Console.SetOut(outFile);

            // тест перенаправленного ввода-вывода
            string s = Console.ReadLine();
            Console.WriteLine(s);
            try
            {
                throw new Exception("what is it?!");
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так...");
            }
            // закрытие потоков ввода-вывода
            inFile.Close();
            outFile.Close();
        }
    }
}
