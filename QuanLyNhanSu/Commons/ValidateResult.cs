using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Commons
{
    public class ValidateResult
    {
        public bool _isNull { get; set; }
        public string _message { get; set; }

        public ValidateResult(bool isNull, string message)
        {
            _isNull = isNull;
            _message = message;
        }
    }
}
