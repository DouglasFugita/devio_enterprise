using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pagamentos.API.Facade
{
    public class PagamentoConfig
    {
        public string DefaultApiKey { get; set; }
        public string DefaultEncryptionKey { get; set; }
    }
}
