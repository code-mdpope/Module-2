using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var system = new ProductManagementSystem();
            while (true)
            {
                Console.WriteLine("\nPoint of Sale Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. List Products by Price Range");
                Console.WriteLine("6. List Low Stock Products");
                Console.WriteLine("7. Calculate Total Inventory Value");
                Console.WriteLine("8. Exit");
                Console.Write("\nChoose an option: ");

                int choice = int.Parse(Console.ReadLine() ?? "8");
                if (choice == 8) break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        system.AddProduct(new Product { Name = name, Price = price, Quantity = quantity });
                        break;

                    case 2:
                        system.ListAllProducts();
                        break;

                    case 3:
                        Console.Write("Enter Product Name to Update: ");
                        name = Console.ReadLine();
                        Console.Write("Enter New Price: ");
                        price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter New Quantity: ");
                        quantity = int.Parse(Console.ReadLine());
                        system.UpdateProduct(name, price, quantity);
                        break;

                    case 4:
                        Console.Write("Enter Product Name to Delete: ");
                        name = Console.ReadLine();
                        system.DeleteProduct(name);
                        break;

                    case 5:
                        Console.Write("Enter Minimum Price: ");
                        decimal minPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Maximum Price: ");
                        decimal maxPrice = decimal.Parse(Console.ReadLine());
                        LinqHandler.ListProductsByPriceRange(system.GetProducts(), minPrice, maxPrice);
                        break;

                    case 6:
                        Console.Write("Enter Stock Threshold: ");
                        int threshold = int.Parse(Console.ReadLine());
                        LinqHandler.ListLowStockProducts(system.GetProducts(), threshold);
                        break;

                    case 7:
                        decimal totalValue = LinqHandler.CalculateTotalInventoryValue(system.GetProducts());
                        Console.WriteLine($"\nTotal Inventory Value: {totalValue:C}");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}