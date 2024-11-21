using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LinqHandler
{
    public static void ListProductsByPriceRange(List<Product> products, decimal minPrice, decimal maxPrice)
    {
        var filteredProducts = products
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
            .OrderBy(p => p.Price)
            .ToList();

        if (!filteredProducts.Any())
        {
            Console.WriteLine("No products found in the given price range.");
            return;
        }

        Console.WriteLine($"\nProducts priced between {minPrice:C} and {maxPrice:C}:");
        filteredProducts.ForEach(p => Console.WriteLine(p));
    }

    public static void ListLowStockProducts(List<Product> products, int threshold)
    {
        var lowStockProducts = products
            .Where(p => p.Quantity < threshold)
            .OrderBy(p => p.Quantity)
            .ToList();

        if (!lowStockProducts.Any())
        {
            Console.WriteLine("No products with low stock.");
            return;
        }

        Console.WriteLine($"\nProducts with stock less than {threshold}:");
        lowStockProducts.ForEach(p => Console.WriteLine(p));
    }

    public static decimal CalculateTotalInventoryValue(List<Product> products)
    {
        return products.Sum(p => p.Price * p.Quantity);
    }
}
