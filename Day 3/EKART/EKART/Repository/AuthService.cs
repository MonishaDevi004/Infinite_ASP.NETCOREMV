using AutoMapper;
using EKART.DTO;
using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repository
{
    public class AuthService : IAuthRepository
    {

        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public AuthService(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //public async Task<CustomerDTO> Login(string username, string password)
        //{
        //    var customer = context.Customers.Include(u => u.Role).FirstOrDefault(c => c.CustomerId == username && c.Password == password);
        //    if (customer == null)
        //    {
        //        return null;
        //    }
        //    return mapper.Map<CustomerDTO>(customer);
        //}


        public async Task<CustomerDTO> Login(string username, string password)
        {
            try
            {
      
                var customer = await context.Customers
     .Where(c => c.CustomerId == username && c.Password == password)
     .Select(c => new
     {
         CustomerId = c.CustomerId,
         RoleName = c.Role.RoleName  // Assuming Role has a RoleName property
     })
     .FirstOrDefaultAsync();
                if (customer == null)
                {
                    return null;
                }

                // Map the complete customer details using AutoMapper
                var customerDTO = mapper.Map<CustomerDTO>(customer);

               

                return customerDTO;
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging configured
                throw new Exception("Error during login process", ex);
            }
        }
    }
}
