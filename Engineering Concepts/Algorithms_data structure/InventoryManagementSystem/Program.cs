using System;

namespace Exercise1_InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            // Add Products
            inventory.AddProduct(new Product(101, "Laptop", 10, 55000));
            inventory.AddProduct(new Product(102, "Mouse", 50, 600));
            inventory.AddProduct(new Product(103, "Keyboard", 30, 1200));

            // Display Products
            inventory.DisplayProducts();

            // Update Product
            inventory.UpdateProduct(102, 75, 650);

            // Delete Product
            inventory.DeleteProduct(103);

            // Display Updated Inventory
            inventory.DisplayProducts();

            Console.ReadKey();
        }
    }
}