using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string email, string password);
        Task<User> CreateUserAsync(string email, string password, string firstname, string lastname);
        Task<IEnumerable<Purchase>> GetPurchases(int userid);
        
    }
}
