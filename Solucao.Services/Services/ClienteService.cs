using Solucao.Domain.Models;
using Solucao.Domain.Response;
using Solucao.Repositories.Interfaces;
using Solucao.Repositories.Repositories;
using System.Net;
using Solucao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

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
            c.DataCadastro = DateTime.Now;
            return _repository.Add(c);
        }

       

        public void Delete(int id)
        {
            var objCliente = _repository.GetById(p => p.Id == id);
            if (objCliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            else
            {
                _repository.Delete(objCliente);
            }

          
        }

        public Response<IEnumerable<Cliente>> GetAll()
        {
            Response<IEnumerable<Cliente>> objResponse = new Response<IEnumerable<Cliente>>();
           
           objResponse.Data = _repository.GetAll();
           
            return objResponse;
        }

        public Cliente GetById(int id)
        {
            return _repository.GetById(p => p.Id == id); ;
        }

        public Cliente Update(Cliente c)
        {
            return _repository.Update(c);
        }

    }
}
