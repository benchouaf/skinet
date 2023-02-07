using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   [ApiController]
   [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
      
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var produts = await _repo.GetProductsAsync();
            return Ok(produts);
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id){
            return await _repo.GetProductAsync(id);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
           return Ok( await _repo.GetProductBrandsAsync());
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypeAsync());
        }

    }
}