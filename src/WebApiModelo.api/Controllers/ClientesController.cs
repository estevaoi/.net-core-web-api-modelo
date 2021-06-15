using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiModelo.business.Services;
using WebApiModelo.comum.ExceptionClass;
using WebApiModelo.domain;
using WebApiModelo.domain.Request;
using WebApiModelo.domain.Response;

namespace WebApiModelo.api.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClientesController : BaseController
    {
        protected readonly ClientesService _service;

        public ClientesController(ClientesService service)
        {
            _service = service;
        }

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<ClientesResponse>))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                return Ok(await _service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Carregar um cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpGet("{clienteId}")]
        [SwaggerResponse(200, Type = typeof(ClientesResponse))]
        [SwaggerResponse(204, Type = typeof(EmptyResult))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> GetCliente(Guid clienteId)
        {
            try
            {
                return Ok(await _service.Get(clienteId));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(200, Type = typeof(ClientesResponse))]
        [SwaggerResponse(204, Type = typeof(EmptyResult))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> PostCliente([FromBody] ClientesRequest request)
        {
            try
            {
                return Ok(await _service.Insert(request));
            }
            catch (NaoExisteException ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atualizar um cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpPut("{clienteId}")]
        [SwaggerResponse(200, Type = typeof(ClientesResponse))]
        [SwaggerResponse(204, Type = typeof(EmptyResult))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> PutCliente([FromBody] ClientesRequest request, Guid clienteId)
        {
            try
            {
                return Ok(await _service.Update(request, clienteId));
            }
            catch (NaoExisteException ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Apagar um cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpDelete("{clienteId}")]
        [SwaggerResponse(204, Type = typeof(EmptyResult))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> DeleteCliente(Guid clienteId)
        {
            try
            {
                var retorno = await _service.Delete(clienteId);
                if (retorno)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new Error { Mensagem = "Não foi possível remover o cliente" });
                }
            }
            catch (NaoExisteException ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new Error { Mensagem = ex.Message });
            }
        }
    }
}