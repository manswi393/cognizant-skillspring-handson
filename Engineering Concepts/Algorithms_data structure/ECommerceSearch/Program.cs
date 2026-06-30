using System;

namespace ECommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Mobile", "Electronics"),
                new Product(103, "Shoes", "Fashion"),
                new Product(104, "Watch", "Accessories"),
                new Product(105, "Headphones", "Electronics")
            };

            Console.Write("Enter Product ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nLinear Search Result");
            Product result1 = SearchOperations.LinearSearch(products, id);

            if (result1 != null)
                result1.Display();
            else
                Console.WriteLine("Product Not Found");

            Console.WriteLine("\nBinary Search Result");
            Product result2 = SearchOperations.BinarySearch(products, id);

            if (result2 != null)
                result2.Display();
            else
                Console.WriteLine("Product Not Found");

            Console.ReadKey();
        }
    }
}