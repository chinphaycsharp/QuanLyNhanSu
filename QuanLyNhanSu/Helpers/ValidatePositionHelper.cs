using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidatePositionHelper
    {
        public static ValidateResult ValidatePosition(this string value, string name)
        {
            ValidateResult result = new ValidateResult(true, "");
            switch (name)
            {
                case "Mscv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Số hợp đồng không được để trống");
                        return result;
                    }
                    break;
                case "TenCv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã chức vụ không được để trống");
                        return result;
                    }
                    break;
                case "MotaCv":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã số nhân viên không được để trống");
                        return result;
                    }
                    break;
                case "Phucaptrachnhiem":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Loại hợp đồng không được để trống");
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
