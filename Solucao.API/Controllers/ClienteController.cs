using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucao.Domain.Models;
using Solucao.Domain.Response;
using Solucao.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Solucao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        /// Retorna os clientes cadastrados de forma paginada
        /// </summary>  
        /// <param name="pageNumber">Número da página para consulta</param>
        /// <param name="pageSize">Número de elementos por página (Máx.: 10)</param>
        /// <response code="200">Retorna os clientes cadastrados</response>
        [HttpGet("paged")]
        public ActionResult<IEnumerable<Cliente>> GetPaginado([FromQuery] int pageNumber,
            [FromQuery] int pageSize, 
            [FromQuery] string filterNome = "", 
            [FromQuery] string filterSobrenome = "",
            [FromQuery] string filterEmail = "",
            [FromQuery] string sortBy = "",
            [FromQuery] string sortOrder = "")
        {
            if(filterNome == null)
            {
                filterNome = "";
            }
            if (filterSobrenome == null)
            {
                filterSobrenome = "";
            }
            if (filterEmail == null)
            {
                filterEmail = "";
            }
            if (sortBy == null)
            {
                sortBy = "Id";
            }
            if (sortOrder == null)
            {
                sortOrder = "asc";
            }

            var page = pageNumber > 0 ? pageNumber : 1;
            var size = pageSize > 0 && pageSize < 100 ? pageSize : 10;
            try
            {
                return Ok(_service.GetPaged(page, size, filterNome, filterSobrenome, filterEmail, sortBy, sortOrder));

            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }

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
            return _service.GetById(id);
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
                _service.Create(cliente);
                Response<Cliente> response = new Response<Cliente>();
                response.Data = cliente;
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Atualiza o registro de um cliente.
        /// </summary>  
        /// <response code="200">Cliente atualizado</response>
        [HttpPut]
        public ActionResult<Response<Cliente>> Update([FromBody] Cliente cliente)
        {
            try
            {
                _service.Update(cliente);
                Response<Cliente> response = new Response<Cliente>();
                response.Data = cliente;
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Exclui o registro de um cliente.
        /// </summary>  
        /// <response code="200">Cliente excluído</response>
        [HttpDelete("{id}")]
        public ActionResult<Response<Cliente>> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
