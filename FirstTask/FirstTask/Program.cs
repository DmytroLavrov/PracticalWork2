using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask
{
    class Student
    {
        double arithmetic;
        int pointN1;
        int pointN2;
        int pointN3;
        string name;
        public double Arithmetic
        {
            get { return arithmetic; }
            set { arithmetic = value; }
        }
        public int PointN1
        {
            get { return pointN1; }
            set { pointN1 = value; }
        }
        public int PointN2
        {
            get { return pointN2; }
            set { pointN2 = value; }
        }
        public int PointN3
        {
            get { return pointN3; }
            set { pointN3 = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Student() { }
        public Student(double arithmetic, int pointN1, int pointN2, int pointN3, string name)
        {
            Arithmetic = arithmetic;
            PointN1 = pointN1;
            PointN2 = pointN2;
            PointN3 = pointN3;
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string way = @"/Users/dmytrolavrov/Projects/PracticalWork2/FirstTask/СписокСтудентів.txt";
            string[] list = File.ReadAllLines(way);
            List<Student> students = new List<Student>();
            List<string> ways = new List<string>();
            foreach (var row in list)
            {
                ways.AddRange(row.Split(' '));
                students.Add(new Student
                {
                    Name = ways[0],
                    PointN1 = Convert.ToInt32(ways[1]),
                    PointN2 = Convert.ToInt32(ways[2]),
                    PointN3 = Convert.ToInt32(ways[3]),
                    Arithmetic = (Convert.ToInt32(ways[1]) + Convert.ToInt32(ways[2]) + Convert.ToInt32(ways[3])) / 3,
                });
                ways.Clear();
            }
            foreach (Student student in students)
            {
                Console.OutputEncoding = System.Text.Encoding.Default;
                Console.WriteLine($"Ім'я: {student.Name} \nСередній бал: {student.Arithmetic} \n");
            }
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Список студентів за середнім балом:");
            students.Sort((student1, student2) => student2.Arithmetic.CompareTo(student1.Arithmetic));
            double ArithmeticMean = students.Average(s => s.Arithmetic);
            List<Student> filteredStudents = students.Where(s => s.Arithmetic >= ArithmeticMean).ToList();
            Console.WriteLine($"Середній бал групи: {ArithmeticMean} \n");
            foreach (Student student in students)
            {
                Console.OutputEncoding = System.Text.Encoding.Default;
                Console.WriteLine($"Ім'я: {student.Name} \nОцінки: {student.PointN1}, {student.PointN2}, {student.PointN3} \nCередній бал студента: {student.Arithmetic} \n");
            }
            Console.ReadKey();
        }
    }
}