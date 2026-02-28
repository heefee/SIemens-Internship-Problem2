namespace SiemensIntershipAssigmnent.Services;

public interface IStoreService
{
    string GetTopSpendingCustomer();
    Dictionary<string, int> GetPopularProducts();
}