using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucao.Domain.Models;
using Solucao.Domain.Response;
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
        public ActionResult<IEnumerable<Cliente>> GetAll()
        {
            return Ok(_service.GetAll());
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
        public ActionResult<Response<Cliente>> Create([FromBody] Cliente cliente)
        {
            try
            {
                this._service.Create(cliente);
                Response<Cliente> response = new Response<Cliente>();
                response.Data = cliente;
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPut]
        public ActionResult<Response<Cliente>> Update([FromBody] Cliente cliente)
        {
            try
            {
                this._service.Update(cliente);
                Response<Cliente> response = new Response<Cliente>();
                response.Data = cliente;
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Response<Cliente>> Delete(int id)
        {
            try
            {
                this._service.Delete(id);
                return Ok("Cliente excluído com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
