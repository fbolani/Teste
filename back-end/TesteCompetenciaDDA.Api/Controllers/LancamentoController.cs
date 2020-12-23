using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCompetenciaDDA.App.Interfaces;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoApp LancamentoApp;
        public LancamentoController(ILancamentoApp lancamentoApp)
        {
            this.LancamentoApp = lancamentoApp;
        }

        /// <summary>
        /// Lista todos os lançamentos
        /// </summary>
        /// <response code="200">Lista de lançamentos</response>
        /// <response code="500">Erro ao obter o lançamentos</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<LancamentoFinanceiro>), 200)]
        public async Task<IActionResult> ListarTodosLancamentosFinanceiros()
        {
            return Ok(await this.LancamentoApp.ListarTodosLancamentosFinanceiros());
        }

        /// <summary>
        /// Obter lançamento por ID
        /// </summary>
        /// <response code="200">Obtem lançamento</response>
        /// <response code="404">Lançamento não encontrado</response>
        /// <response code="500">Erro ao obter o lançamento</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<LancamentoFinanceiro>), 200)]
        public async Task<IActionResult> ObterPorID(int id)
        {
            var result = await this.LancamentoApp.ObterPorID(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        /// <summary>
        /// Cadastrar lançamento
        /// </summary>
        /// <response code="200">Lançamento cadastrado com sucesso</response>
        /// <response code="500">Erro ao cadastrar o lançamento</response>
        [HttpPost]
        public async Task<IActionResult> Post(LancamentoFinanceiro signature)
        {
            await this.LancamentoApp.AdicionarLancamentoFinanceiro(signature);
            return Ok();
        }

        /// <summary>
        /// Atualizar lançamento
        /// </summary>
        /// <response code="200">Lançamento atualizado com sucesso</response>
        /// <response code="404">Lançamento não encontrado para ser atualizado</response>
        /// <response code="500">Erro ao atualizar o lançamento</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LancamentoFinanceiro signature)
        {
            signature.Id = id;
            bool result = await this.LancamentoApp.AtualizarLancamentoFinanceiro(signature);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Excluir lançamento
        /// </summary>
        /// <response code="200">Lançamento excluído com sucesso</response>
        /// <response code="404">Lançamento não encontrado para ser excluído</response>
        /// <response code="500">Erro ao excluir o lançamento</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.LancamentoApp.ExcluirLancamentoFinanceiro(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}