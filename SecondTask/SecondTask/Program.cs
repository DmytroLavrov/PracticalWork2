using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SecondTask
{
    class Worker
    {
        int salary;
        int workexperience;
        string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int WorkExperience
        {
            get { return workexperience; }
            set { workexperience = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public Worker() { }
        public Worker(int salary, int workexperience, string name)
        {
            Salary = salary;
            WorkExperience = workexperience;
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string way = @"/Users/dmytrolavrov/Projects/PracticalWork2/SecondTask/SecondTask/СписокРобітників.txt";
            string[] list = File.ReadAllLines(way);
            List<Worker> workers = new List<Worker>();
            List<string> type = new List<string>();
            foreach (var row in list)
            {
                type.AddRange(row.Split(' '));
                workers.Add(new Worker
                {
                    Name = type[0],
                    WorkExperience = Convert.ToInt32(type[1]),
                    Salary = Convert.ToInt32(type[2]),
                });
                type.Clear();
            }
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"Ім'я: {worker.Name} \nРоки досвіду: {worker.WorkExperience} \nЗарплата: {worker.Salary} \n");
            }
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Список співробітників за роками досвіду:");
            workers.Sort((worker1, worker2) => worker2.WorkExperience.CompareTo(worker1.WorkExperience));
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"Ім'я: {worker.Name} \nРоки досвіду: {worker.WorkExperience} \n");
            }

            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Список співробітників за зарплатою:");
            workers.Sort((worker1, worker2) => worker2.Salary.CompareTo(worker1.Salary));
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"Ім'я: {worker.Name} \nЗарплата: {worker.Salary} \n");
            }
            Console.ReadKey();
        }
    }
}