using ApiCashRegistry.DTOs;
using ApiCashRegistry.Models;
using ApiCashRegistry.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiCashRegistry.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderRespository _orderRespository;
        private ProductRepository _productRespository;
        private UserRespository _userRespository;

        public OrderController(OrderRespository orderRespository, ProductRepository productRespository, UserRespository userRespository)
        {
            _orderRespository = orderRespository;
            _productRespository = productRespository;
            _userRespository = userRespository;
        }



        //Ajouter une commande => DTO List OrderPorductRequest (id_produit, qty)
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OrderRequestDTO orderRequestDTO)
        {
            Order order = new Order();
            var userClaims = HttpContext.User;
            string email = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            CashRegistryUser user = _userRespository.SearchOne(u => u.Email == email);
            if(user != null)
            {
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
                order.User = user;
                order.UpdateAmount();
                if (_orderRespository.Save(order))
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
            return Unauthorized();
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
