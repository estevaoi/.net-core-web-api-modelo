using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiModelo.data.DataContext;
using WebApiModelo.domain.Dtos;
using WebApiModelo.domain.Entities;
using WebApiModelo.domain.Interfaces;

namespace WebApiModelo.data.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly ToJobContext _context;

        public ClientesRepository(ToJobContext context)
        {
            _context = context;
        }

        private const string _QUERY_SELECT = @"
            SELECT
                [CLIENTE_ID],
                [NOME],
                [DOCUMENTO],
                [SITUACAO],
                [DATA_CRIACAO],
                [DATA_MODIFICACAO]
            FROM
	            [ACESSOS].[CLIENTES]
        ";

        private const string _QUERY_INSERT = @"
            INSERT INTO [ACESSOS].[CLIENTES]
                (
                    [CLIENTE_ID],
                    [NOME],
                    [DOCUMENTO],
                    [SITUACAO],
                    [DATA_CRIACAO],
                    [DATA_MODIFICACAO]
                )
                VALUES
                (
                    @ClienteId,
                    @Nome,
                    @Documento,
                    @Situacao,
                    @DataCriacao,
                    @DataModificacao
                )
        ";

        private const string _QUERY_UPDATE = @"
            UPDATE
                [ACESSOS].[CLIENTES]
            SET
                [NOME] = @Nome,
                [DOCUMENTO] = @Documento,
                [SITUACAO] = @Situacao,
                [DATA_MODIFICACAO] = @DataModificacao
            WHERE
                [CLIENTE_ID] = @ClienteId
        ";

        private const string _QUERY_DELETE = @"
            DELETE
                FROM [ACESSOS].[CLIENTES]
            WHERE
                [CLIENTE_ID] = @ClienteId
        ";

        private readonly DateTime _DATE_NOW = DateTime.Now;

        public async Task<List<ClientesEntity>> Get()
        {
            var retorno = await _context.Connection.QueryAsync<ClientesEntity>(_QUERY_SELECT);
            return retorno.ToList();
        }

        public async Task<ClientesEntity> Get(Guid clienteId)
        {
            var retorno = await _context.Connection.QueryAsync<ClientesEntity>(_QUERY_SELECT + @"WHERE [CLIENTE_ID] = @ClienteId", new { clienteId });
            return retorno.FirstOrDefault();
        }

        public async Task<bool> Insert(ClientesDto dto)
        {
            try
            {
                var retorno = await _context.Connection.ExecuteAsync(_QUERY_INSERT, new
                {
                    dto.ClienteId,
                    dto.Documento,
                    dto.Nome,
                    dto.Situacao,
                    DataCriacao = _DATE_NOW,
                    DataModificacao = _DATE_NOW
                });

                return retorno == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(ClientesDto dto, Guid clienteId)
        {
            try
            {
                var retorno = await _context.Connection.ExecuteAsync(_QUERY_UPDATE, new
                {
                    ClienteId = clienteId,
                    dto.Documento,
                    dto.Nome,
                    dto.Situacao,
                    DataModificacao = _DATE_NOW
                });

                return retorno == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Guid clienteId)
        {
            try
            {
                await _context.Connection.ExecuteAsync(_QUERY_DELETE, new { clienteId });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}