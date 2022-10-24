namespace ApiCashRegistry.DTOs
{
    public class OrderResponseDTO
    {
        public decimal TotalAmount { get; set; }

        public List<OrderProductResponseDTO> Products { get; set; }

        public OrderResponseDTO()
        {
            Products = new List<OrderProductResponseDTO>();
        }
    }
}
