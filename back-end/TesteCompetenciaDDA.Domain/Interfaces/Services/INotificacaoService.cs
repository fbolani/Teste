using System.Collections.Generic;

namespace TesteCompetenciaDDA.Domain.Interfaces.Services
{
    public interface INotificacaoService
    {
        bool HasNotificacao();
        List<string> GetNotificacoes();
        void AddNotificacao(string mensagem);
    }
}