using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Well_Choosen.Classes
{
   static class Session
    {
        private static Felhasz jelenlegi;

        public static Felhasz Jelenlegi
        {
            get { return jelenlegi; }
            set { jelenlegi = value; }
        }
        public static string SHAHash(string szoveg)
        {
            return BitConverter.ToString(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(szoveg))).Replace("-", "").ToLower();
        }

    }
}
