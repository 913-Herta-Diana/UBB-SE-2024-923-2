using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IDataEncryptionService
    {
        Dictionary<string, string> Encrypt(string data);
        string Decrypt(string data, string key);
    }
}
