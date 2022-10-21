namespace BankRestAPI.DTOs
{
    public class OperationResponseDTO
    {
        public int Id { get; set; }
        public DateTime OperationDateTime { get; set; }

        public decimal Amount { get; set; }
        public int AccountId { get; set; }
    }
}
