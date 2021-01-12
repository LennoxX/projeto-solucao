using Microsoft.AspNetCore.Mvc;
using Solucao.Domain.Models;
using Solucao.Services.Interfaces;
using Solucao.Services.Services;
using System;
using System.Collections.Generic;

namespace Solucao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados. Atenção, pode causar lentidão.
        /// </summary>  
        /// <response code="200">Retorna todos os clientes cadastrados</response>
        [HttpGet] 
        public ICollection<Cliente> GetAll()
        {
            return this._service.GetAll();
        }

        /// <summary>
        /// Retorna o cliente referente ao ID informado.
        /// </summary>  
        /// <param name="id"></param>
        /// <response code="200">Cliente encontrado</response>
        /// <response code="404">Cliente não encontrado</response>
        [HttpGet("{id}")]
        public Cliente GetById(int id)
        {
            return this._service.GetById(id);
        }

        /// <summary>
        /// Cria um cliente novo.
        /// </summary>  
        /// <response code="201">Cliente cadastrado</response>
        [HttpPost]
        [ProducesResponseType(201)]
        public Cliente Create([FromBody] Cliente cliente)
        {
            return this._service.Create(cliente);
        }

        [HttpPut]
        public Cliente Update([FromBody] Cliente cliente)
        {
            return this._service.Update(cliente);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.Delete(id);
        }
    }
}
