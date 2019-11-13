using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;
using MovieShop.Data;

namespace MovieShop.Services
{
    public class UserService : IUserService
    {
        private readonly ICryptoService _cryptoService;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,ICryptoService cryptoservice)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoservice;
        }
        public async Task<User> CreateUserAsync(string email, string password, string firstname, string lastname)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser != null)
            {
                return null; 
            }
            var salt = _cryptoService.CreateSalt();
            var hashpassword = _cryptoService.HashPassword(password, salt);
            var user = new User
            {
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                HashedPassword = hashpassword,
                Salt = salt
            };

            var CreatedUser = await _userRepository.AddAsync(user);
            return CreatedUser;
        }

        public async Task<IEnumerable<Purchase>> GetPurchases(int userid)
        {
            return await _userRepository.GetUserPurchaseMovies(userid);
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            
            if (dbUser != null)
            {
                var dbHashedPassword = dbUser.HashedPassword;
                var dbsalt = dbUser.Salt;
                var userHashedPassword = _cryptoService.HashPassword(password, dbsalt);
                if (dbHashedPassword == userHashedPassword)
                {
                    return dbUser;
                }
                   
            }
             return null;

            

            
        }
    }
}
