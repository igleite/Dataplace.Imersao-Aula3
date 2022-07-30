using Dataplace.Core.Domain.Events;
using Dataplace.Core.Domain.Interfaces;
using Dataplace.Core.Domain.Localization.Messages.Extensions;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoEventHandler :
        INotificationHandler<OrcamentoAdicionadoEvent>,
        INotificationHandler<OrcamentoAtualizadoEvent>,
        INotificationHandler<OrcamentoExcluidoEvent>,
        INotificationHandler<OrcamentoFechadoEvent>,
        INotificationHandler<OrcamentoReabertoEvent>,
        INotificationHandler<OrcamentoCanceladoEvent>,
        INotificationHandler<ItemAdicionadoEvent>,
        INotificationHandler<ItemAtualizadoEvent>,
        INotificationHandler<ItemExcluidoEvent>
    {
        #region fields
        private readonly IEnvironmentService _environmentService;
        private readonly ISymphonyLogService _symphonyLogService;
        #endregion

        #region constructor
        public OrcamentoEventHandler(IEnvironmentService environmentService, ISymphonyLogService symphonyLogService)
        {
            _environmentService = environmentService;
            _symphonyLogService = symphonyLogService;
        }
        #endregion

        #region methods orcamento

        public async Task Handle(OrcamentoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Adição";
            var tipo = "Linha";
            var descricao = "Adição de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(OrcamentoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Alteração";
            var tipo = "Linha";
            var descricao = "Alteração de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(OrcamentoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Exclusão";
            var tipo = "Linha";
            var descricao = "Exclusão de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(OrcamentoFechadoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Processamento";
            var tipo = "Linha";
            var descricao = "Fechamento de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(OrcamentoReabertoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Processamento";
            var tipo = "Linha";
            var descricao = "Reabertura de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(OrcamentoCanceladoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Processamento";
            var tipo = "Linha";
            var descricao = "Cancelamento de Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }
        #endregion

        #region methods orcamento item
        public async Task Handle(ItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Adição";
            var tipo = "Linha";
            var descricao = "Adição de Item do Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(ItemAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Atualização";
            var tipo = "Linha";
            var descricao = "Atualização de Item do Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

        public async Task Handle(ItemExcluidoEvent notification, CancellationToken cancellationToken)
        {
            var cdEmpresa = _environmentService.GetCdEmpresa();
            var cdFilial = _environmentService.GetCdFilial();
            var origem = notification.GetType().Name;
            var categoria = "Exclusão";
            var tipo = "Linha";
            var descricao = "Exclusão de Item do Orçamento";
            var detalhe = JsonConvert.SerializeObject(notification);
            _symphonyLogService.Register(cdEmpresa, cdFilial, origem, categoria, tipo, descricao, detalhe);
        }

    

        #endregion
    }
}
