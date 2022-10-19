using Microsoft.AspNetCore.Mvc;
using VideoStore.Models;
using VideoStore.Repositories;

namespace AspNetVideoStore.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private CustomerRespository _customerRespository;

        public CustomerController(CustomerRespository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        [HttpGet("")]
        public List<Customer> DisplayCustomers()
        {
            return _customerRespository.FindAll();
        }

        [HttpGet("display/{id}")]
        public Customer DisplayCustomer(int id)
        {
            return _customerRespository.FindById(id);
        }

        [HttpGet("search/{search}")]
        public List<Customer> DisplayCustomers(string search)
        {
            return _customerRespository.Search(c => c.FirstName.Contains(search) || c.LastName.Contains(search));
        }

        [HttpPost("add")]
        public Customer Add([FromBody] Customer customer)
        {
            if (_customerRespository.Save(customer))
            {
                return customer;
            }
            return null;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteCustomer(int id)
        {
            Customer customer = _customerRespository.FindById(id);
            if (customer != null)
            {
                return _customerRespository.Delete(customer);
            }
            return false;
        }

        [HttpPut("update/{id}")]
        public bool Update(int id, [FromBody] Customer newcustomer)
        {
            Customer customer = _customerRespository.FindById(id);
            if (customer != null)
            {
                customer.FirstName = newcustomer.FirstName;
                customer.LastName = newcustomer.LastName;
                customer.Phone = newcustomer.Phone;
                return _customerRespository.Update();
            }
            return false;
        }
    }
}
