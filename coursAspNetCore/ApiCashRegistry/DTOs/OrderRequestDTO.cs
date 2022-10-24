namespace ApiCashRegistry.DTOs
{
    public class OrderRequestDTO
    {
        public List<OrderProductRequestDTO> Products { get; set; }

        public OrderRequestDTO()
        {
            Products = new List<OrderProductRequestDTO>();
        }
    }
}
