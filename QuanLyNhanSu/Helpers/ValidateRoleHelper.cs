using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidateRoleHelper
    {
        public static ValidateResult ValidateRole(this string value, string name, string value2)
        {
            ValidateResult result = new ValidateResult(true, "");
            switch (name)
            {
                case "MaQuyen":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mã không được để trống");
                        return result;
                    }
                    break;
                case "MoTa":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mô tả không được để trống");
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
