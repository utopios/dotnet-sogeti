using ApiCashRegistry.DTOs;
using ApiCashRegistry.Models;
using ApiCashRegistry.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCashRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderRespository _orderRespository { get; set; }
        private ProductRepository _productRespository { get; set; }

        public OrderController(OrderRespository orderRespository, ProductRepository productRespository)
        {
            _orderRespository = orderRespository;
            _productRespository = productRespository;
        }



        //Ajouter une commande => DTO List OrderPorductRequest (id_produit, qty)
        [HttpPost]
        public IActionResult Post([FromBody] OrderRequestDTO orderRequestDTO)
        {
            Order order = new Order();
            orderRequestDTO.Products.ForEach(p =>
            {
                Product product = _productRespository.FindById(p.ProductId);
                if (product != null)
                {
                    OrderProduct orderProduct = new OrderProduct() { Product = product, Order = order, Qty = p.Qty };
                    order.Products.Add(orderProduct);
                    product.Stock -= p.Qty;
                }
            });
            order.UpdateAmount();
            if(_orderRespository.Save(order))
            {
                OrderResponseDTO response = new OrderResponseDTO();
                response.TotalAmount = order.Amount;
                order.Products.ForEach(p =>
                {
                    response.Products.Add(new OrderProductResponseDTO() { Name = p.Product.Name, Qty = p.Qty, Price = p.Product.Price, TotalAmount = p.Qty * p.Product.Price });
                });
                return Ok(response);
            }
            return StatusCode(500);
        }

        //Réponse Order => (total, List OrderProductResponse (Name, qty, price, total)
        [HttpGet]
        public IActionResult Get()
        {
            List<OrderResponseDTO> response = new List<OrderResponseDTO>();
            _orderRespository.FindAll().ForEach(order =>
            {
                OrderResponseDTO responseDTO = new OrderResponseDTO();
                responseDTO.TotalAmount = order.Amount;
                order.Products.ForEach(p =>
                {
                    responseDTO.Products.Add(new OrderProductResponseDTO() { Name = p.Product.Name, Qty = p.Qty, Price = p.Product.Price, TotalAmount = p.Qty * p.Product.Price });
                });
                response.Add(responseDTO);
            });
            return Ok(response);
        }
    }
}
