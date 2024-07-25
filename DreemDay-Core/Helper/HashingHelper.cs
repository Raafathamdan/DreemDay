using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Helper
{
    public static class HashingHelper
    {
       public static string GenerateSHA384String (string input)
        {
            SHA384 sha384 = SHA384Managed.Create ();
            byte[] bytes = Encoding.UTF8.GetBytes (input);
            byte[] hash = sha384.ComputeHash (bytes);
            return GetStringFromHash(hash);
        }
       private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder ();
            for (int i = 0; i < hash.Length; i++) 
            {
                result.Append (hash[i].ToString("X2"));
            }
            return result.ToString ();
        }
        public static bool IsHash(string inputString)
        {
            return inputString.Length == 96 && !inputString.Any(c => char.IsWhiteSpace(c));
        }
    }
}
