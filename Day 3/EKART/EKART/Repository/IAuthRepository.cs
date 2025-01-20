using EKART.DTO;

namespace EKART.Repository
{
    public interface IAuthRepository
    {
        Task<CustomerDTO> Login(string username, string password);
    }
}
