using Assignment.DTO;
using Assignment.Entities;

namespace Assignment.Businesslogic.Interface
{
    public interface CustomerInterface
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByID(Guid id);
        Task<Guid> AddNewCustomers(CustomerDTO model);
        Task<Guid?> UpdateCustomer(CustomerDTO model);
        Task<bool> DeleteCustomer(Guid id);
        
    }
}
