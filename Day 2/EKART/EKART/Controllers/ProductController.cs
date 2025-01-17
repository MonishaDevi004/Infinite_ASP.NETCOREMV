using EKART.DTO;
using EKART.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EKART.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        #region DisplayProducts
        [Route("ViewProducts")]
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
        #endregion

        #region GetProduct
        [Route("GetParticularProduct/{id:int}")]
        public async Task<IActionResult> GetProduct([FromQuery] int id)
        {
            ProductDTO product = await productRepository.GetProductById(id);
            return View(product);
        }
        #endregion

        #region CreateProduct
        public async Task<IActionResult> Create()
        {
            var categories = await productRepository.GetCategories();
            var suppliers = await productRepository.GetSuppliers();

            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,ReorderLevel,Discontinued")] ProductDTO productDTO)
        {
            /*var categories = await productRepository.GetCategories();
            var suppliers = await productRepository.GetSuppliers();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName",productDTO.CategoryId);
            ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName",productDTO.SupplierId);*/

            try
            {
                //writing the controller validation logic
                if (productDTO.ProductName.ToLower() == "sample" || productDTO.ProductName.ToLower() == "dummy")
                {
                    ModelState.AddModelError("ProductName", "Product Name cannot be SAMPLE or DUMMY!!");
                }
                if (productDTO.QuantityPerUnit == null)
                {
                    ModelState.AddModelError("QuantityPerUnit", "QuantityPerUnit value should be greater than 0");
                }
                if (!ModelState.IsValid)
                {
                    return View();

                }

            }

            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
            await productRepository.CreateProduct(productDTO);
            return RedirectToAction("DisplayProducts");





        }
        [Route("constraint/{name:maxlength(10)}")]
        public IActionResult RoutingDemo(string name)
        {
            return View();
        }

        #endregion


        #region CallingProcedure

        public async Task<IActionResult> TenProduct()
        {
            var productItem = await productRepository.TenProductProcedure();
            return View(productItem);
        }

        #endregion

        [Route("GetCustomerOrder/{CID:alpha:length(5)}")]
        public async Task<IActionResult> GetCustomerOrder(string CID)
        {
          var CustomerOrder =  await productRepository.GetCustOrder(CID);
            return View(CustomerOrder);
        }
    }
}
