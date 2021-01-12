using Solucao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Services.Interfaces
{
    public interface IClienteService
    {
        ICollection<Cliente> GetAll();

        Cliente Create(Cliente c);

        Cliente GetById(int id);

        Cliente Update(Cliente c);

        void Delete(int id);
    }
}
