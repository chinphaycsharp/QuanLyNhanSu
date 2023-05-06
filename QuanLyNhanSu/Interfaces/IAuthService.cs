namespace QuanLyNhanSu.Interfaces
{
    public interface IAuthService
    {
        int Auth(string username, string password);
        int Register(string username, string password, string confirmpassword, string email);
    }
}
