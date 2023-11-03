using Assignment.Businesslogic.Interface;
using Assignment.DTO;
using Assignment.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment.Businesslogic.Service
{
    public class CustomerService : CustomerInterface
    {
        #region property
        private readonly TestContext _dbContext;
        private readonly IMapper _mapper;

        #endregion
      
        #region constructor
        public CustomerService(TestContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Method
        public async Task<Guid> AddNewCustomers(CustomerDTO model)
        {
            Guid customerId = Guid.NewGuid();
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                
                var entity=_mapper.Map<Customer>(model);    
                entity.CustomerId = customerId; 
                await _dbContext.Customers.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

            }
            return customerId;  
        }

        public async Task<bool> DeleteCustomer(Guid id)
        {
            bool isSuccess = false;
            using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            var data = await _dbContext.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            if (data != null)
            {
                 _dbContext.Customers.Remove(data);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                isSuccess = true;
            }
            return isSuccess;
            
        }

        public async Task<List<Customer>> GetAllCustomers()
        {

            var result = await _dbContext.Customers.OrderBy(c => c.CustomerName).AsNoTracking().ToListAsync();
            return result;
            
        }

        public async Task<Customer> GetCustomerByID(Guid id)
        {
            var result = await _dbContext.Customers.OrderBy(c => c.CustomerName).Where(x=>x.CustomerId==id).FirstOrDefaultAsync();
            return result; 
        }

        public async Task<Guid?> UpdateCustomer(CustomerDTO model)

        {
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                var originalEntity = await _dbContext.Customers.Where(x => x.CustomerId == model.CustomerId).FirstOrDefaultAsync();

                if (originalEntity != null)
                {
                    Customer entity=_mapper.Map<Customer>(model);      
                    _dbContext.Entry(originalEntity).CurrentValues.SetValues(entity);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
            }
            return model.CustomerId;    
        }
        #endregion
    }
}
