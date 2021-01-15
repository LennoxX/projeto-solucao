using Solucao.Domain.Models;
using Solucao.Repositories.Context;
using Solucao.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Repositories.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
         
    }
}
