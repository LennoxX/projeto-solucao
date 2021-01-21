using Solucao.Domain.Models;
using Solucao.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Services.Interfaces
{
    public interface IClienteService
    {
        Response<IEnumerable<Cliente>> GetAll();

        Page<Cliente> GetPaged(int page, int size, string filterNome, string filterSobrenome, string filterEmail, string sortBy = "", string sortOrder = "");

        Cliente Create(Cliente c);

        Cliente GetById(int id);

        Cliente Update(Cliente c);

        void Delete(int id);
    }
}
