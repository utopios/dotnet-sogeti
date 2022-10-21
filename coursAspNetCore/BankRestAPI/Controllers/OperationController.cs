using BankAccountProject.Classes;
using BankAccountProject.DAO;
using BankRestAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankRestAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private AccountDAO _accountDAO;
        private OperationDAO _operationDAO;

        public OperationController(AccountDAO accountDAO, OperationDAO operationDAO)
        {
            _accountDAO = accountDAO;
            _operationDAO = operationDAO;
        }

        [HttpPost("{accountId}/{operationType}")]
        public IActionResult Post(int accountId, string operationType, [FromForm] decimal amount)
        {
            Account account = _accountDAO.FindById(accountId);
            account.Operations = _operationDAO.FindAll(accountId);
            if(account != null)
            {
                if (operationType == "withdrawal")
                {
                    Operation operation = new Operation( Math.Abs(amount) * -1);
                    if(_operationDAO.Save(operation, accountId) && account.WithDraw(operation) && _accountDAO.Update(account))
                    {
                        return Ok(new OperationResponseDTO()
                        {
                            AccountId = accountId,
                            Amount = operation.Amount,
                            OperationDateTime = operation.OperationDateTime,
                            Id = operation.Id
                        });
                    }
                }
                else if (operationType == "deposit")
                {
                    Operation operation = new Operation(Math.Abs(amount));
                    if (_operationDAO.Save(operation, accountId) && account.Deposit(operation) && _accountDAO.Update(account))
                    {
                        return Ok(new OperationResponseDTO()
                        {
                            AccountId = accountId,
                            Amount = operation.Amount,
                            OperationDateTime = operation.OperationDateTime,
                            Id = operation.Id
                        });
                    }
                }
                else
                {
                    return StatusCode(402);
                }
                
            }
            return NotFound();
        }

        [HttpGet("{accountId}")]
        public IActionResult Get(int accountId)
        {
            List<Operation> operations = _operationDAO.FindAll(accountId);
            List<OperationResponseDTO> responseDTOs = new List<OperationResponseDTO>();
            operations.ForEach(o =>
            {
                responseDTOs.Add(new OperationResponseDTO()
                {
                    AccountId = accountId,
                    Amount = o.Amount,
                    OperationDateTime = o.OperationDateTime,
                    Id = o.Id
                });
            });
            return Ok(responseDTOs);
        }
    }
}
