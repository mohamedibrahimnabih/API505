using ECommerce.DTO;
using ECommerce.Models;
using ECommerce.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listOfProduct = productRepository.Get(null, includeProperties: e => e.Category);

            // DTO
            List<ProductDTO> listOfProductDTOs = new();
            foreach (var item in listOfProduct)
            {
                ProductDTO ProductDTO = new()
                {
                    Name = item.Name,
                    CategoryName = item.Category.Name,
                    CategoryId = item.Category.Id,
                    Description = item.Description,
                    Img = item.Img,
                    Price = item.Price,
                    Rate = item.Rate
                };
                listOfProductDTOs.Add(ProductDTO);
            }

            return Ok(listOfProductDTOs);
        }

        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                Product product = new()
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    CategoryId = productDTO.CategoryId,
                    Img = productDTO.Img,
                    Price = productDTO.Price,
                    Rate = productDTO.Rate
                };
                productRepository.Add(product);
                return Ok(product);
            }
            return BadRequest(productDTO);
        }
    }
}
