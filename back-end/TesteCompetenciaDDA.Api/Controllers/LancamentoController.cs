using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Entities;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService LancamentoService;
        private readonly INotificacaoService NotificacaoService;
        public LancamentoController(ILancamentoService lancamentoService, INotificacaoService notificacaoService)
        {
            this.LancamentoService = lancamentoService;
            this.NotificacaoService = notificacaoService;
        }

        /// <summary>
        /// Lista todos os lançamentos
        /// </summary>
        /// <response code="200">Lista de lançamentos</response>
        /// <response code="400">Erro ao obter os lançamentos</response>
        [HttpGet]
        public async Task<IActionResult> ListarTodosLancamentosFinanceiros()
        {
            try
            {
                return Ok(await this.LancamentoService.ListarTodosLancamentosFinanceiros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter lançamento por ID
        /// </summary>
        /// <response code="200">Obtem lançamento</response>
        /// <response code="400">Erro ao obter o lançamento</response>
        /// <response code="404">Lançamento não encontrado</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorID(int id)
        {
            try
            {
                var result = await this.LancamentoService.ObterPorID(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar lançamento
        /// </summary>
        /// <response code="200">Lançamento cadastrado com sucesso</response>
        /// <response code="400">Erro ao cadastrar o lançamento</response>
        [HttpPost]
        public async Task<IActionResult> Post(LancamentoFinanceiro signature)
        {
            try
            {
                await this.LancamentoService.AdicionarLancamentoFinanceiro(signature);
                if (!this.NotificacaoService.HasNotificacao())
                    return Ok();
                else
                    return BadRequest(this.NotificacaoService.GetNotificacoes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar lançamento
        /// </summary>
        /// <response code="200">Lançamento atualizado com sucesso</response>
        /// <response code="400">Erro ao atualizar o lançamento</response>
        /// <response code="404">Lançamento não encontrado para ser atualizado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LancamentoFinanceiro signature)
        {
            try
            {
                var lancto = await this.LancamentoService.ObterPorID(id);
                if (lancto == null)
                    return NotFound();

                signature.Id = id;
                await this.LancamentoService.AtualizarLancamentoFinanceiro(signature);
                if (!this.NotificacaoService.HasNotificacao())
                    return Ok();
                else
                    return BadRequest(this.NotificacaoService.GetNotificacoes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir lançamento
        /// </summary>
        /// <response code="200">Lançamento excluído com sucesso</response>
        /// <response code="400">Erro ao excluir o lançamento</response>
        /// <response code="404">Lançamento não encontrado para ser excluído</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var lancto = await this.LancamentoService.ObterPorID(id);
                if (lancto == null)
                    return NotFound();

                await this.LancamentoService.ExcluirLancamentoFinanceiro(id);
                if (!this.NotificacaoService.HasNotificacao())
                    return Ok();
                else
                    return BadRequest(this.NotificacaoService.GetNotificacoes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Lista lançamentos por data
        /// </summary>
        /// <response code="200">Lista de lançamentos</response>
        /// <response code="400">Erro ao obter os lançamentos</response>
        [HttpGet("dia/{data}")]
        public async Task<IActionResult> Get(DateTime data)
        {
            try
            {
                return Ok(await this.LancamentoService.ListarLancamentosDia(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}