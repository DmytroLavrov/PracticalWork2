using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdTask
{
    class Product
    {
        int price;
        string food;
        string type;
        public string Food
        {
            get { return food; }
            set { food = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Product() { }
        public Product(int price, string food, string type)
        {
            Price = price;
            Food = food;
            Type = type;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string way = @"/Users/dmytrolavrov/Projects/PracticalWork2/ThirdTask/ThirdTask/СписокПродуктів.txt";
            string[] list = File.ReadAllLines(way);
            List<Product> products = new List<Product>();
            List<string> model = new List<string>();
            foreach (var row in list)
            {
                model.AddRange(row.Split(' '));
                products.Add(new Product
                {
                    Food = model[0],
                    Price = Convert.ToInt32(model[1]),
                    Type = model[2],
                });
                model.Clear();
            }
            foreach (Product product in products)
            {
                Console.OutputEncoding = System.Text.Encoding.Default;
                Console.WriteLine($"Продукт: {product.Food} \nЦіна: {product.Price} \nКатегорія: {product.Type} \n");
            }
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Список продуктів за категоріями:");
            var groupOfProducts = products.GroupBy(p => p.Type);
            foreach (var group in groupOfProducts)
            {
                Console.OutputEncoding = System.Text.Encoding.Default;
                Console.WriteLine($"Категорія: {group.Key}");
                Console.WriteLine("Продукти:");
                foreach (var product in group)
                {
                    Console.WriteLine($" {product.Food}");
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}