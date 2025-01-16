using AutoMapper;
using EKART.DTO;
using EKART.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repository
{
    public class ProductService : IProductRepository
    {
        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public ProductService(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

       public async Task<ProductDTO> GetProductById(int id)
        {
           Product product = await context.Products.FindAsync(id);
            return mapper.Map<ProductDTO>(product);
        }

       public async Task<List<ProductDTO>> GetProducts()
        {
            List<Product> products = await context.Products.ToListAsync();
            return mapper.Map<List<Product>, List<ProductDTO>>(products);
        }
    }
}
