using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStore.Pagamentos.NerdPag
{
    public class NerdsPagService
    {
        public readonly string ApiKey;
        public readonly string EncryptionKey;

        public NerdsPagService(string apiKey, string encryptionKey)
        {
            ApiKey = apiKey;
            EncryptionKey = encryptionKey;
        }
    }
}
