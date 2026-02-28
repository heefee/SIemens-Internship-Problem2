using SiemensIntershipAssigmnent.Models;

namespace SiemensIntershipAssigmnent.Services;

public class StoreService : IStoreService
{
    public List<Customer> Customers { get; set; } = new List<Customer>();
    
    //2.3 method that finds and returns the name of the customer who has spent the most money on all their orders
    public string GetTopSpendingCustomer()
    {
        var topCustomer = Customers
            .OrderByDescending(c => c.Orders.Sum(o => o.CalculateFinalPrice()))
            .FirstOrDefault();

        return topCustomer?.Name ?? "No customers found";
    }
    
    //2.4 method that returns the popular products along with their total quantity sold
    public Dictionary<string, int> GetPopularProducts()
    {
        var productSales = Customers
            .SelectMany(c => c.Orders)
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .ToDictionary(
                group => group.Key, 
                group => group.Sum(i => i.Quantity)
            );
        
        return productSales
            .OrderByDescending(kvp => kvp.Value)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}