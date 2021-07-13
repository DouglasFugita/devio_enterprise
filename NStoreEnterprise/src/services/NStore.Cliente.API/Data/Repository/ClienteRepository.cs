using Microsoft.EntityFrameworkCore;
using NStore.Clientes.API.Models;
using NStore.Core.Data;
using NStore.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Clientes.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Add(cliente);
        }


        public async Task<Cliente> ObterPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Clientes.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
