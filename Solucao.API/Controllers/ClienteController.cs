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

        [HttpGet]
        public ICollection<Cliente> GetAll()
        {
            return this._service.GetAll();
        }

        [HttpGet("{id}")]
        public Cliente GetById(int id)
        {
            return this._service.GetById(id);
        }

        [HttpPost]
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
