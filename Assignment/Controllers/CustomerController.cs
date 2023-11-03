using Assignment.Businesslogic.Interface;
using Assignment.Businesslogic.Service;
using Assignment.DTO;
using Assignment.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region property
        CustomerInterface _customersService;
        #endregion

        #region constructor
        public CustomerController(CustomerInterface customersService)
        {

            _customersService = customersService;

        }
        #endregion

        #region method

        [Route("GetAll")]
        [HttpGet]
        public Task<List<Customer>> GetAllMethod()
        {

            var result = _customersService.GetAllCustomers();
            return result;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddMethod(CustomerDTO model)
        {
            var id = _customersService.AddNewCustomers(model);
            if (id == null)
            {
                return BadRequest(new { isSuccess = false, message = "Something went wrong." });
            }
            return Ok(new { isSuccess = true, message = "Data inserted Successfully.", id = id });

        }
        [Route("GetById")]
        [HttpGet]
        public Task<Customer> GetByIDMethod(Guid id)
        {

            var result = _customersService.GetCustomerByID(id);
            return result;
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> EditMethod(CustomerDTO model)
        {

            var id = _customersService.UpdateCustomer(model);
            if (id == null)
            {
                return BadRequest(new { isSuccess = false, message = "Something went wrong." });
            }
            return Ok(new { isSuccess = true, message = "Data inserted Successfully. ", id = id });

        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMethod(Guid id)
        {
            var isDeleted = await _customersService.DeleteCustomer(id);
            if (!isDeleted)
            {
                return BadRequest(new { isSuccess = false, message = "Something went wrong." });
            }
            return Ok(new { isSuccess = true, message = "Data Deleted Successfully." });

        }
        #endregion
    }
}
