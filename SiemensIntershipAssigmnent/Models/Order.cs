namespace SiemensIntershipAssigmnent.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    
    // 2.2 Calculate final price with discount policy
    public decimal CalculateFinalPrice()
    {
        decimal total = Items.Sum(item => item.Quantity * item.UnitPrice);
        
        // If the total value exceeds 500€, apply a 10% discount
        if (total > 500m)
        {
            total -= total * 0.10m; 
        }
        
        return total;
    }
}