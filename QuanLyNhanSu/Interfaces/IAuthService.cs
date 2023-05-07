using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interfaces
{
    public interface IAuthService
    {
        Login Auth(string username, string password);
    }
}
