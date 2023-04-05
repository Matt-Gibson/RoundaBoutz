using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Client.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> All();
    Task<Customer?> GetCustomer(Guid id);
    Task<Customer?> AddCustomer(Customer customer);
    Task<bool> Update(Customer customer);
    Task<bool> Delete(Guid id);
}