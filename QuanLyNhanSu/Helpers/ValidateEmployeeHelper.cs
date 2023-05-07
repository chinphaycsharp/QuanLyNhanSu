using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidateEmployeeHelper
    {
        public static ValidateResult ValidateEmployee(this string value, string name, string value2)
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
                case "HotenNv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Họ tên không được để trống");
                        return result;
                    }
                    break;
                case "Gioitinh":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Giới tính không được để trống");
                        return result;
                    }
                    break;
                case "QueQuan":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Quê quán không được để trống");
                        return result;
                    }
                    break;
                case "Sđt":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "SDT không được để trống");
                        return result;
                    }
                    break;
                case "SoCmtnd":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "CMND/CCCD không được để trống");
                        return result;
                    }
                    break;
                case "Điachithuongtru":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Địa chỉ không được để trống");
                        return result;
                    }
                    break;
                case "Idlogin":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Tài khoản không được để trống");
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
