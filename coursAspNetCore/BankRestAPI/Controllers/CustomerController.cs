using BankAccountProject.Classes;
using BankAccountProject.DAO;
using BankRestAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankRestAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerDAO _customerDAO;

        public CustomerController(CustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }


        //Créer le client
        [HttpPost]
        public IActionResult Post([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            Customer customer = new Customer(customerRequestDTO.FirstName, customerRequestDTO.LastName, customerRequestDTO.Phone, customerRequestDTO.Email);
            if(_customerDAO.Save(customer))
            {
                return Ok(new CustomerResponseDTO()
                {
                    Customer = customerRequestDTO,
                    Id = customer.Id
                });
            }
            return StatusCode(500);
        }
    }
}
