using System.Collections.Generic;
using TesteCompetenciaDDA.Domain.Interfaces.Services;

namespace TesteCompetenciaDDA.Domain.Services
{
    public class NotificacaoService: INotificacaoService
    {
        private readonly List<string> Notificacoes;
        public NotificacaoService()
        {
            Notificacoes = new List<string>();
        }

        public bool HasNotificacao()
        {
            return Notificacoes.Count > 0;
        }

        public List<string> GetNotificacoes()
        {
            return Notificacoes;
        }

        public void AddNotificacao(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
                Notificacoes.Add(mensagem);
        }
    }
}