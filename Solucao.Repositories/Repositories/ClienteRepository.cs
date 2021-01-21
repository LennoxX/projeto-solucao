using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Models;
using Solucao.Domain.Response;
using Solucao.Repositories.Context;
using Solucao.Repositories.Interfaces;
using System;
using System.Linq;

namespace Solucao.Repositories.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
            
        }
        public Page<Cliente> GetPaged(int pageNumber, 
            int pageSize, 
            string filterNome, 
            string filterSobrenome, 
            string filterEmail, 
            string sortBy = "Id", 
            string sortOrder = "asc")
        {
            IQueryable<Cliente> tmpList = GetAll(filterNome, filterSobrenome, filterEmail, sortBy, sortOrder);
            Page<Cliente> Pageable = new Page<Cliente>();
   
            Pageable.Content = tmpList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            Pageable.Size = Pageable.Content.Count();
            Pageable.TotalElements = tmpList.Count();
            Pageable.PageIndex = pageNumber;
            Pageable.TotalPages = (int)Math.Ceiling(decimal.Divide(Pageable.TotalElements, pageSize));

            return Pageable;
        }


        public IQueryable<Cliente> GetAll(string filterNome = "", 
            string filterSobrenome = "", 
            string filterEmail = "", 
            string sortBy = "", 
            string sortOrder = "")
        {

            if(sortOrder != "asc")
            {
                return _context.Set<Cliente>()
                .Where(c => c.Nome.Contains(filterNome.ToLower()))
                .Where(c => c.Sobrenome.Contains(filterSobrenome.ToLower()))
                .Where(c => c.Email.Contains(filterEmail.ToLower()))
                .OrderByDescending(c => EF.Property<object>(c, sortBy))
                .AsNoTracking();
            } else
            {
                return _context.Set<Cliente>()
               .Where(c => c.Nome.Contains(filterNome.ToLower()))
               .Where(c => c.Sobrenome.Contains(filterSobrenome.ToLower()))
               .Where(c => c.Email.Contains(filterEmail.ToLower()))
               .OrderBy(c => EF.Property<object>(c, sortBy))
               .AsNoTracking();
            }

            
        }

    }
}
