using System;
using System.Collections.Generic;

namespace Exercise1_InventoryManagement
{
    public class Inventory
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            if (!products.ContainsKey(product.ProductId))
            {
                products.Add(product.ProductId, product);
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("Product ID already exists.");
            }
        }

        public void UpdateProduct(int id, int quantity, double price)
        {
            if (products.ContainsKey(id))
            {
                products[id].Quantity = quantity;
                products[id].Price = price;
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DeleteProduct(int id)
        {
            if (products.Remove(id))
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n------ Inventory ------");

            foreach (Product product in products.Values)
            {
                Console.WriteLine(product);
            }
        }
    }
}