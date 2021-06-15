using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiModelo.comum;
using WebApiModelo.domain.Dtos;
using WebApiModelo.domain.Interfaces;
using WebApiModelo.domain.Request;
using WebApiModelo.domain.Response;

namespace WebApiModelo.business.Services
{
    public class ClientesService
    {
        private readonly IClientesRepository _repository;

        public ClientesService(IClientesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClientesResponse>> Get()
        {
            var listaClientes = new List<ClientesResponse>();
            var clientes = await _repository.Get();

            if (clientes != null)
            {
                foreach (var cliente in clientes)
                {
                    listaClientes.Add(new ClientesResponse
                    {
                        ClienteId = cliente.CLIENTE_ID,
                        Nome = cliente.NOME,
                        Documento = cliente.DOCUMENTO,
                        Situacao = cliente.SITUACAO
                    });
                }
            }

            return listaClientes;
        }

        public async Task<ClientesResponse> Get(Guid clienteId)
        {
            var cliente = await _repository.Get(clienteId);

            if (cliente == null)
            {
                throw new NaoExisteException("Cliente não encontrado");
            }

            return new ClientesResponse
            {
                ClienteId = cliente.CLIENTE_ID,
                Nome = cliente.NOME,
                Documento = cliente.DOCUMENTO,
                Situacao = cliente.SITUACAO
            };
        }

        public async Task<ClientesResponse> Insert(ClientesRequest request)
        {
            var dataRequest = request.Cast<ClientesDto>();

            dataRequest.ClienteId = Guid.NewGuid();

            if (await _repository.Insert(dataRequest))
            {
                return new ClientesResponse
                {
                    ClienteId = dataRequest.ClienteId,
                    Nome = dataRequest.Nome,
                    Documento = dataRequest.Documento,
                    Situacao = dataRequest.Situacao
                };
            }
            else
            {
                throw new Exception("Erro ao cadastrar o cliente");
            }
        }

        public async Task<ClientesResponse> Update(ClientesRequest request, Guid clienteId)
        {
            if (await _repository.Get(clienteId) == null)
            {
                throw new NaoExisteException("Não foi encontrado o cliente");
            }

            var dataRequest = request.Cast<ClientesDto>();

            if (await _repository.Update(dataRequest, clienteId))
            {
                return new ClientesResponse
                {
                    ClienteId = clienteId,
                    Nome = dataRequest.Nome,
                    Documento = dataRequest.Documento,
                    Situacao = dataRequest.Situacao
                };
            }
            else
            {
                throw new Exception("Erro ao atualizar o cliente");
            }
        }

        public async Task<bool> Delete(Guid clienteId)
        {
            if (await _repository.Get(clienteId) == null)
            {
                throw new NaoExisteException("Não foi encontrado o cliente");
            }

            return await _repository.Delete(clienteId);
        }
    }
}