using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Helpers
{
    public static class ValidateAccountHelper
    {
        public static ValidateResult ValidateAccount(this string value,string name, string value2)
        {
            ValidateResult result = new ValidateResult(true,"");
            switch(name)
            {
                case "username":
                    if(value == null)
                    {
                        result = new ValidateResult(false,"Tài khoản không được để trống");
                        return result;
                    }
                    break;
                case "password":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Mật khẩu không được để trống");
                        return result;
                    }
                    break;
                case "email":
                    if (value == null)
                    {
                        result = new ValidateResult(false, "Email không được để trống");
                        return result;
                    }
                    break;
                default:
                    break;
            }
            if(value2 != "")
            {
                if (value != value2)
                {
                    result = new ValidateResult(false, "Mật khẩu không khớp"); ;
                }
            }
            return result;
        }
    }
}
