using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FourthTask
{
    class Program
    {
        delegate int WorkWithLine(string Range);
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            List<string> String = new List<string> {"Футболка", "Штани", "Сорочка", "Світшот"};
            WorkWithLine Length = s => s.Length;
            foreach (string Range in String)
            {
                Console.WriteLine($"Слово: {Range} \nДовжина рядка: {Length(Range)} \n");
            }
            Console.ReadKey();
        }
    }
}