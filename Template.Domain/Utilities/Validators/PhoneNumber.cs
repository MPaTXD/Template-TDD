using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Utilities.Validators
{
    public static class PhoneNumber
    {
        public static bool IsValid(string number)
        {
            if (number.Length != 11) return false;

            return true;
        }
    }
}
