using NStore.Core.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NStore.Clientes.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);

        Task<Cliente> ObterPorCpf(string cpf);
        Task<IEnumerable<Cliente>> ObterTodos();
    }
}
