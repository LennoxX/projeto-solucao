using Solucao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);

        Cliente Update(Cliente cliente);

        ICollection<Cliente> GetAll();

        Cliente GetById(int id);

        void Delete(int id);
    }
}
