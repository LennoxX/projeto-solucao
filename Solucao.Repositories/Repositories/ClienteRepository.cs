using Solucao.Domain.Models;
using Solucao.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Repositories.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente Create(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            return new Cliente()
            {
                Id = id
            };
        }

        public Cliente Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
