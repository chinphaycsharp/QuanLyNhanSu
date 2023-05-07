using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidateContractHelper
    {
        public static ValidateResult ValidateContract(this string value, string name)
        {
            ValidateResult result = new ValidateResult(true, "");
            switch (name)
            {
                case "SoHd":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Số hợp đồng không được để trống");
                        return result;
                    }
                    break;
                case "Mscv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã chức vụ không được để trống");
                        return result;
                    }
                    break;
                case "Msnv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã số nhân viên không được để trống");
                        return result;
                    }
                    break;
                case "LoaiHd":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Loại hợp đồng không được để trống");
                        return result;
                    }
                    break;
                case "HesoluongCb":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Hệ số lương không được để trống");
                        return result;
                    }
                    break;
                case "MucluongCb":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mức lương cơ bản không được để trống");
                        return result;
                    }
                    break;
                case "DieukhoanHd":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Điều khoản không được để trống");
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
