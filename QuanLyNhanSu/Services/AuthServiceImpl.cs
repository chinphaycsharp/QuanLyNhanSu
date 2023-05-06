using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using System.Linq;

namespace QuanLyNhanSu.Services
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly QuanLyNhanSuContext _dbContext;
        public AuthServiceImpl(QuanLyNhanSuContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Login Auth(string username, string password)
        {
            var userLogin = _dbContext.Logins.Where(x=>x.Username == username && x.Password == EncryptionHelper.ToMD5(password)).FirstOrDefault();
            if (userLogin != null)
            {
                return userLogin;
            }
            return default;
        }

        public int Register(string username, string password, string confirmpassword, string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
