using Microsoft.AspNetCore.Mvc;
using OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;
using OnlineShopapi.Repositories;
using OnlineShopapi.Repositories.Repositories;

namespace OnlineShopapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCatogoryRepository _catogoryRepository;
        

        public ProductController(IProductRepository productRepository, IProductCatogoryRepository catogoryRepository)
        {
            _productRepository = productRepository;
            _catogoryRepository = catogoryRepository;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
        {
            var p = await _productRepository.AddProductAsync(addProductDto);
            return Ok($"{p!.Name} with {p!.Id} is registered");
        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var p = await _productRepository.GetProductAsync(id);
            return Ok(p!=null ? p:"productId not found!!!!!");

        }
        [HttpGet]
        [Route("FilterbyCatogorid/{CatogoryId}")]
        public async Task<IActionResult> Filter(int CatogoryId)
        {
            List<Product>? productList= await _productRepository.FilterProductByCIdAsync(CatogoryId);
            return Ok(productList!=null ? productList:"No Any Product in CtogoryId");

        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllProduct()
        {
            var p = await _productRepository.GetAllProductAsync();
            return Ok(p!=null ? p:"productId not found!!!!!");

        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] UpdateProductDto updateProductDto)
        {
            var p=await _productRepository.UpdateProductAsync(id,updateProductDto);
            return Ok(p!=null ?$"{p!.Id} updated successfully":"productId not found!!!!!");

        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var p=await _productRepository.RemoveProductAsync(id);
            return Ok(p!=null ? $"{p!.Name} was Removed":"productId not found!!!!!");

        }

        [HttpPost]
        [Route("/api/Catogory/Add")]
        public async Task<IActionResult> AddCatogory([FromBody] AddCatogoryDto addCatogoryDto)
        {
            ProductCatogory? c = await _catogoryRepository.AddCatogoryAsync(addCatogoryDto) ;
            return Ok($"{c!.Name} with {c!.Id} is registered");
        }
        [HttpGet]
        [Route("/api/Catogory/Get/{id}")]
        public async Task<IActionResult> GetCatogory(int id)
        {
            ProductCatogory? c = await _catogoryRepository.GetCatogoryAsync(id);
            return Ok(c!=null ? c:"productId not found!!!!!");
        }
        [HttpGet]
        [Route("/api/Catogory/GetAll")]
        public async Task<IActionResult> GetAllCatogory()
        {
            List<ProductCatogory>? c = await _catogoryRepository.GetAllCatogoryAsync();
            return Ok(c!=null ? c:"productId not found!!!!!");
        }
        

    }
}