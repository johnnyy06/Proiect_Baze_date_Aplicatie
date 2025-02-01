using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoFlow.Helpers
{
    internal class Hash
    {
        public static string EncryptPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return EncryptPassword(password) == hash;
        }
    }
}
