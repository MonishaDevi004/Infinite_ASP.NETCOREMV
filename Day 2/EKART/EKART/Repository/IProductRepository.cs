using EKART.DTO;
using EKART.Models;

namespace EKART.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);

        Task CreateProduct(ProductDTO productDTO);

        Task<IEnumerable<SupplierDTO>> GetSuppliers();
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<List<Ten_Most_Expensive_Products>> TenProductProcedure();

        Task<List<CustOrdersOrders>> GetCustOrder(string customerid);
    }
}
