using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext _context { get; }
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async  Task<Product> GetProductAsync(int id)
        {
           return  await _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
           .FirstOrDefaultAsync(p=>p.Id.Equals(id));
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
           return await _context.productBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}