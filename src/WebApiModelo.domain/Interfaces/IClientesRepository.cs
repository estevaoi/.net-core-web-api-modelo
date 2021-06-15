using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiModelo.domain.Dtos;
using WebApiModelo.domain.Entities;

namespace WebApiModelo.domain.Interfaces
{
    public interface IClientesRepository
    {
        Task<List<ClientesEntity>> Get();

        Task<ClientesEntity> Get(Guid clienteId);

        Task<bool> Insert(ClientesDto cliente);

        Task<bool> Update(ClientesDto cliente, Guid clienteId);

        Task<bool> Delete(Guid clienteId);
    }
}