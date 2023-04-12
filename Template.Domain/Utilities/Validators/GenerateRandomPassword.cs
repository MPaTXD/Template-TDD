using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Utilities
{
   public static class GenerateRandom
    {
        public static string GetPassword(int LengthPassword = 7)
        {
            string Password = BitConverter.ToString(new System.Security.Cryptography.SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(DateTime.Now.Ticks.ToString()))).Replace("-", String.Empty);
            Password = Password.Substring(0, LengthPassword);
          
            return Password;
        }

        public static string Getkey(int LengthPassword = 10)
        {
            string Password = BitConverter.ToString(new System.Security.Cryptography.SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(DateTime.Now.Ticks.ToString()))).Replace("-", String.Empty);
            Password = Password.Substring(0, LengthPassword);

            return Password;
        }
    }
}
