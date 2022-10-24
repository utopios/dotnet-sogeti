namespace ApiCashRegistry.DTOs
{
    public class OrderProductResponseDTO
    {
        public string Name { get; set; }

        public string Qty { get; set; }

        public decimal Price { get; set; }

        public decimal TotalAmount { get; set; }
    }
}