namespace BankRestAPI.DTOs
{
    public class AccountResponseDTO
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public CustomerResponseDTO Customer { get; set; }

        public List<OperationResponseDTO> Operations{ get; set; }
    }
}
