using System;
using SiemensIntershipAssigmnent.Models;
using SiemensIntershipAssigmnent.Services;

namespace SiemensIntershipAssigmnent
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new StoreService();

            // create first customer (no discount)
            var c1 = new Customer { CustomerId = 1, Name = "Alice" };
            var o1 = new Order { OrderId = 101, CustomerId = 1 };
            
            o1.Items.Add(new OrderItem { ProductName = "Headphones", Quantity = 2, UnitPrice = 100m });
            o1.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 50m });
            c1.Orders.Add(o1);

            // create second customer to test the > 500 euro discount
            var c2 = new Customer { CustomerId = 2, Name = "Bob" };
            var o2 = new Order { OrderId = 102, CustomerId = 2 };
            
            o2.Items.Add(new OrderItem { ProductName = "Laptop", Quantity = 1, UnitPrice = 800m });
            o2.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 2, UnitPrice = 50m });
            c2.Orders.Add(o2);

            store.Customers.Add(c1);
            store.Customers.Add(c2);

            // print results to check if methods work
            Console.WriteLine("Order Totals:");
            Console.WriteLine($"Alice total: {o1.CalculateFinalPrice()}");
            Console.WriteLine($"Bob total: {o2.CalculateFinalPrice()}"); // should be 810

            Console.WriteLine("\nTop Spender:");
            Console.WriteLine(store.GetTopSpendingCustomer());

            Console.WriteLine("\nPopular Products sold:");
            var products = store.GetPopularProducts();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Key}: {p.Value}");
            }
        }
    }
}