using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalancoController : ControllerBase
    {
        private readonly INotificacaoService NotificacaoService;
        private readonly IBalancoService BalancoService;
        public BalancoController(IBalancoService balancoService, INotificacaoService notificacaoService)
        {
            this.BalancoService = balancoService;
            this.NotificacaoService = notificacaoService;
        }

        /// <summary>
        /// Lista os Balancos do Mes
        /// </summary>
        /// <response code="200">Lista do baçanco do mes</response>
        /// <response code="400">Erro ao obter o relatório</response>
        [HttpGet("{mes}")]
        public async Task<IActionResult> Get(int mes)
        {
            try
            {
                return Ok(await this.BalancoService.ListarBalancos(mes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Conciliar o dia
        /// </summary>
        /// <response code="200">Data conciliada com sucesso</response>
        /// <response code="400">Erro ao concilar a data</response>
        [HttpPost("{data}")]
        public async Task<IActionResult> Post(DateTime data)
        {
            try
            {
                await this.BalancoService.ConcilarDia(data);
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
    }
}