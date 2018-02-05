using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kalender.BL
{
    class hashValue
    {
        
        public string Hash(string Value)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Value));
            byte[] hashs = sha1.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (var hash in hashs)
            {
                sb.Append(hash.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
