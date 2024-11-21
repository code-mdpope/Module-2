using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductManagementSystem
{
    private List<Product> _products = new List<Product>();

    public List<Product> GetProducts() => _products;

    public void AddProduct(Product product)
    {
        if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Error: Product with this name already exists.");
            return;
        }
        _products.Add(product);
        Console.WriteLine("Product added successfully.");
    }

    public void ListAllProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }
        Console.WriteLine("\nAvailable Products:");
        _products.ForEach(p => Console.WriteLine(p));
    }

    public void UpdateProduct(string name, decimal price, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            Console.WriteLine("Error: Product not found.");
            return;
        }
        product.Price = price;
        product.Quantity = quantity;
        Console.WriteLine("Product details updated successfully.");
    }

    public void DeleteProduct(string name)
    {
        var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            Console.WriteLine("Error: Product not found.");
            return;
        }
        _products.Remove(product);
        Console.WriteLine("Product removed successfully.");
    }
}
