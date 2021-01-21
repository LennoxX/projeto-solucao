using Solucao.Domain.Models;
using Solucao.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solucao.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Page<Cliente> GetPaged(int pageNumber, int pageSize, string filterNome, string filterSobrenome, string filterEmail, string sortBy="", string sortOrder="");

        IQueryable<Cliente> GetAll(string filterNome = "", string filterSobrenome = "", string filterEmail = "", string sortBy = "", string sortOrder = "");
 
    }
}
