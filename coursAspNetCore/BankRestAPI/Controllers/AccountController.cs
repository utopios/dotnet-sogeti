using BankAccountProject.Classes;
using BankAccountProject.DAO;
using BankRestAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankRestAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private CustomerDAO _customerDAO;
        private AccountDAO _accountDAO;
        

        public AccountController(CustomerDAO customerDAO, AccountDAO accountDAO)
        {
            _customerDAO = customerDAO;
            _accountDAO = accountDAO;
        }



        //Créer un compte courant 
        [HttpPost("customer/{customerId}")]
        public IActionResult Post(int customerId, [FromForm] decimal amount)
        {
            Customer customer = _customerDAO.FindById(customerId);
            if(customer != null)
            {
                Account account = new SimpleAccount()
                {
                    Customer = customer,
                    TotalAmount = amount
                };
                if(_accountDAO.Save(account))
                {
                    AccountResponseDTO response = new AccountResponseDTO()
                    {
                        Customer = new CustomerResponseDTO()
                        {
                            Id = customer.Id,
                            Customer = new CustomerRequestDTO()
                            {
                                FirstName = customer.FirstName,
                                LastName = customer.LastName,
                                Phone = customer.Phone,
                                Email = customer.Email,
                            }
                        },
                        Id = account.Id,
                        TotalAmount = account.TotalAmount,

                    };
                    response.Operations = new List<OperationResponseDTO>();
                    return Ok(response);
                }
                return StatusCode(500);
            }
            return StatusCode(402);
        }

        [HttpGet("{accountId}")]
        public IActionResult Get(int accountId)
        {
            Account account = _accountDAO.FindById(accountId);
            if(account != null)
            {
                AccountResponseDTO response = new AccountResponseDTO()
                {
                    Customer = new CustomerResponseDTO()
                    {
                        Id = account.Customer.Id,
                        Customer = new CustomerRequestDTO()
                        {
                            FirstName = account.Customer.FirstName,
                            LastName = account.Customer.LastName,
                            Phone = account.Customer.Phone,
                            Email = account.Customer.Email,
                        }
                    },
                    Id = account.Id,
                    TotalAmount = account.TotalAmount,
                };
                return Ok(response);
            }
            return NotFound();
        }


    }
}
