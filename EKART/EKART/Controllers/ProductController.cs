using EKART.DTO;
using EKART.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> DisplayProducts()
        {
            List<ProductDTO> products = await productRepository.GetProducts();
            try
            {
                if (products.Count < 0)
                {
                    throw new Exception("Data Not Found!!");
                }
            }
           
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return View(products);

        }

        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDTO product = await productRepository.GetProductById(id);
            return View(product);
        }
    }
}
