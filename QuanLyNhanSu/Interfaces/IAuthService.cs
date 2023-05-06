using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interfaces
{
    public interface IAuthService
    {
        Login Auth(string username, string password);
        int Register(string username, string password, string confirmpassword, string email);
    }
}
