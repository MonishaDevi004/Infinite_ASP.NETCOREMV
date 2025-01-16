using EKART.DTO;

namespace EKART.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
    }
}
