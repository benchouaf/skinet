using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   [ApiController]
   [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var produts = await _context.Products.ToListAsync();
            return Ok(produts);
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id){
            return await _context.Products.FindAsync(id);
        }

    }
}