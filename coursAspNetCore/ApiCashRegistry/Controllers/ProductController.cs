using ApiCashRegistry.DTOs;
using ApiCashRegistry.Models;
using ApiCashRegistry.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCashRegistry.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Ajouter un produit, DTO (name, price, stock)
        [Authorize(Policy ="admin")]
        [HttpPost]
        public IActionResult Post([FromBody] ProductRequestDTO productRequestDTO)
        {
            Product product = new Product()
            {
                Name = productRequestDTO.Name,
                Price = productRequestDTO.Price,
                Stock = productRequestDTO.Stock
            };
            if(_productRepository.Save(product))
            {
                return Ok(new ProductResponseDTO() { Id = product.Id, Price = product.Price, Name = product.Name });
            }
            return StatusCode(500);
        }


        //Récupérer un produit DTO (id, name, price)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _productRepository.FindById(id);
            if(product != null)
            {
                return Ok(new ProductResponseDTO() { Id = product.Id, Price = product.Price, Name = product.Name });
            }
            return NotFound();
        }
        //Récupérer un plusieurs produits List DTO (id, name, price)

        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<ProductResponseDTO> response = new List<ProductResponseDTO>();
            if(search == null)
            {
                _productRepository.FindAll().ForEach(product =>
                {
                    response.Add(new ProductResponseDTO() { Id = product.Id, Price = product.Price, Name = product.Name });
                });
            }
            else
            {
                _productRepository.SearchAll(p => p.Name.Contains(search)).ForEach(product =>
                {
                    response.Add(new ProductResponseDTO() { Id = product.Id, Price = product.Price, Name = product.Name });
                });
            }
            return Ok(response);
        }
    }
}
