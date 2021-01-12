using Solucao.Domain.Models;
using Solucao.Repositories.Interfaces;
using Solucao.Repositories.Repositories;
using Solucao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solucao.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Cliente Create(Cliente c)
        {
            return _repository.Create(c);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ICollection<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Cliente Update(Cliente c)
        {
            return _repository.Update(c);
        }
    }
}
