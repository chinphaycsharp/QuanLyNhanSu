using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidateRevenueEmployeeHelper
    {
        public static ValidateResult ValidateRevenueEmployee(this string value, string name)
        {
            ValidateResult result = new ValidateResult(true, "");
            switch (name)
            {
                case "Msnv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã nhân viên không được để trống");
                        return result;
                    }
                    break;
                case "DoanhThu":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Doanh thu không được để trống");
                        return result;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
