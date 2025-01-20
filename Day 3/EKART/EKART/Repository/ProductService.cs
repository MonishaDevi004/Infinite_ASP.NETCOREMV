using AutoMapper;
using EKART.DTO;
using EKART.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Data.SqlClient;
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

        private bool IsProductExists(int id)
        {
            return context.Products.Any(p => p.ProductId == id);
        }

        public async Task CreateProduct(ProductDTO productDTO)
        {
            Product product = null;
            if (!IsProductExists(productDTO.ProductId))
            {
                product = mapper.Map<Product>(productDTO);
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<SupplierDTO>> GetSuppliers()
        {
            List<Supplier> suppliers = await context.Suppliers.Select(s => new Supplier
            {
                SupplierId = s.SupplierId,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                City = s.City,
                ContactTitle = s.ContactTitle,
                Address = s.Address,

            }).ToListAsync();


            return mapper.Map<List<SupplierDTO>>(suppliers);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await context.Categories.Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToListAsync();

            return mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<List<Ten_Most_Expensive_Products>> TenProductProcedure()
        {
            return await context.Ten_Most_Expensive_Products.FromSqlRaw("[dbo].[Ten Most Expensive Products]").ToListAsync();
        }


        public async Task<List<CustOrdersOrders>> GetCustOrder(string customerid)
        {
            SqlParameter CustomerName = new SqlParameter("@CustomerID", customerid);
            return await context.CustOrdersOrders.FromSqlRaw("[dbo].[CustOrdersOrders] @CustomerID", CustomerName).ToListAsync();
    }

    }


}
