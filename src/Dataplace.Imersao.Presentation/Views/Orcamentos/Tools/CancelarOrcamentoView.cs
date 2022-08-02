using Dataplace.Core.Application.Services.Results;
using Dataplace.Core.Comunications;
using Dataplace.Core.Domain.Localization.Messages.Extensions;
using Dataplace.Core.Domain.Notifications;
using Dataplace.Core.win.Controls.List.Behaviors;
using Dataplace.Core.win.Controls.List.Behaviors.Contracts;
using Dataplace.Core.win.Controls.List.Configurations;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using dpLibrary05.Infrastructure.Helpers;
using dpLibrary05.Infrastructure.Helpers.Permission;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataplace.Imersao.Presentation.Views
{
    public partial class CancelarOrcamentoView : dpLibrary05.Infrastructure.UserControls.ucSymGen_ToolDialog
    {
        #region fields
        private DateTime _startDate;
        private DateTime _endDate;
        private const int _itemSeg = 467;
        private IListBehavior<OrcamentoViewModel, OrcamentoQuery> _orcamentoList;
        #endregion

        #region constructors
        public CancelarOrcamentoView()
        {
            InitializeComponent();

            _orcamentoList = new C1TrueDBGridListBehavior<OrcamentoViewModel, OrcamentoQuery>(gridOrcamento)
                .WithConfiguration(GetConfiguration());

            this.ToolConfiguration += CancelamentoOrcamentoView_ToolConfiguration;
            this.BeforeProcess += CancelamentoOrcamentoView_BeforeProcess;
            this.Process += CancelamentoOrcamentoView_Process;
            this.AfterProcess += CancelamentoOrcamentoView_AfterProcess;


            this.tsiMarcar.Click += TsiMarcar_Click;
            this.tsiDesmarca.Click += TsiDesmarca_Click;
            this.tsiExcel.Click += TsiExcel_Click;

            this.KeyDown += CancelamentoOrcamentoView_KeyDown;


            this.chkAberto.Click += chk_Click;
            this.chkFechado.Click += chk_Click;
            this.chkCancelado.Click += chk_Click;


            _startDate = DateTime.Today;
            _endDate = _startDate.AddDays(1).AddSeconds(-1);
            rangeDate.Date1.Value = _startDate;
            rangeDate.Date2.Value = _endDate;
        }

        private void TsiExcel_Click(object sender, EventArgs e)
        {
            clsOffice.ExportTrueDbGridToExcel(gridOrcamento, xlsOption.xlsSaveAndOpen);
        }

        #endregion

        #region tool events
        private void CancelamentoOrcamentoView_ToolConfiguration(object sender, ToolConfigurationEventArgs e)
        {
            // definições iniciais do projeto
            // item seguraça
            // engine code
            this.Text = "Cancelar orçamentos em aberto";
            e.SecurityIdList.Add(_itemSeg);
            e.CancelButtonVisisble = true;
        }

        private void CancelamentoOrcamentoView_BeforeProcess(object sender, BeforeProcessEventArgs e)
        {

            var permission = PermissionControl.Factory().ValidatePermission(_itemSeg, dpLibrary05.mGenerico.PermissionEnum.Execute);
            if (!permission.IsAuthorized())
            {
                e.Cancel = true;
                this.Message.Info(permission.BuildMessage());
                return;
            }

            var itensSelecionados = _orcamentoList.GetCheckedItems();
            if(itensSelecionados.Count() == 0)
            {
                e.Cancel = true;
                this.Message.Info(53727.ToMessage());
                return;
            }

            e.Parameter.Items.Add("itensSelecionados", itensSelecionados);
        }

        private async void CancelamentoOrcamentoView_Process(object sender, ProcessEventArgs e)
        {
           
            if (!(e.Parameter.Items.get_Item("itensSelecionados").Value is IEnumerable<OrcamentoViewModel> itensSelecionados))
            {
                e.Cancel = true;
                return;
            }

            e.ProgressMinimum = 0;
            e.ProgressMaximum = itensSelecionados.Count();
            e.BeginProcess();
            // um a um
            foreach (var item in itensSelecionados)
            {
                using ( var scope = dpLibrary05.Infrastructure.ServiceLocator.ServiceLocatorScoped.Factory())
                {
                    var command = new CancelarOrcamentoCommand(item);
                    
                    var mediator = scope.Container.GetInstance<IMediatorHandler>();
                    var notifications = scope.Container.GetInstance<INotificationHandler<DomainNotification>>();

                    await mediator.SendCommand(command);
                    item.Result = Result.ResultFactory.New(notifications.GetNotifications());
                    if (item.Result.Success)
                    {
                        item.IsSelected = false;
                        item.Situacao = Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Cancelado.ToDataValue();
                    }
                }
                e.LogBuilder.Items.Add($"Orçamento {item.NumOrcamento} cancelado", dpLibrary05.Infrastructure.Helpers.LogBuilder.LogTypeEnum.Information);

                System.Threading.Thread.Sleep(1000);


                if (e.CancellationRequested)
                    break;

                e.ProgressValue += 1;
            }

            e.EndProcess();
        }

        private void CancelamentoOrcamentoView_AfterProcess(object sender, AfterProcessEventArgs e)
        {
         
        }
        #endregion

        #region list events
        private ViewModelListBuilder<OrcamentoViewModel> GetConfiguration()
        {
            var configuration = new ViewModelListBuilder<OrcamentoViewModel>();

            configuration.AllowFilter();
            configuration.AllowSort();
            configuration.HasHighlight(x => {
                x.Add(orcamento => orcamento.Situacao == Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Cancelado.ToDataValue(), System.Drawing.Color.Red);
            });

            configuration.WithQuery<OrcamentoQuery>(() => GetQuery() );

            configuration.Ignore(x => x.CdEmpresa);
            configuration.Ignore(x => x.CdFilial);
            configuration.Ignore(x => x.SqTabela);
            configuration.Ignore(x => x.CdTabela);
            configuration.Ignore(x => x.DtFechamento);
            configuration.Ignore(x => x.CdVendedor);
            //configuration.Ignore(x => x.Usuario);
            configuration.Ignore(x => x.DataValidade);
            configuration.Ignore(x => x.DiasValidade);


            configuration.Property(x => x.NumOrcamento)
                .HasMinWidth(100)
                .HasCaption("#");

            configuration.Property(x => x.CdCliente)
               .HasMinWidth(100)
               .HasCaption("Cliente");

            configuration.Property(x => x.DsCliente)
                    .HasMinWidth(300)
                    .HasCaption("Razão");

            configuration.Property(x => x.DtOrcamento)
                .HasMinWidth(100)
                .HasCaption("Data")
                .HasFormat("d");

            configuration.Property(x => x.ValotTotal)
                .HasMinWidth(100)
                .HasCaption("Total")
                .HasFormat("n");

            configuration.Property(x => x.Situacao)
                  .HasMinWidth(100)
                  .HasCaption("Situação")
                  .HasValueItems(x =>
                  {
                      x.Add(OrcamentoStatusEnum.Aberto.ToDataValue(), 3469.ToMessage());
                      x.Add(OrcamentoStatusEnum.Fechado.ToDataValue(), 3846.ToMessage());
                      x.Add(OrcamentoStatusEnum.Cancelado.ToDataValue(), 3485.ToMessage());
                  });

            return configuration;
        }

        private OrcamentoQuery GetQuery()
        {
            var situacaoList = new List<Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum>();
            if (chkAberto.Checked)
                situacaoList.Add(Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Aberto);
            if (chkFechado.Checked)
                situacaoList.Add(Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Fechado);
            if (chkCancelado.Checked)
                situacaoList.Add(Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Cancelado);

            DateTime? dtInicio = null;
            DateTime? dtFim = null;
            if (rangeDate.Date1.Value is DateTime d)
                dtInicio = d;

            if (rangeDate.Date2.Value is DateTime d2)
                dtFim = d2;

            var query = new OrcamentoQuery() { SituacaoList = situacaoList, DtInicio =  dtInicio, DtFim =  dtFim };

            return query;
        }

        #endregion

        #region contol events
        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            await _orcamentoList.LoadAsync();
        }

        private void TsiDesmarca_Click(object sender, EventArgs e)
        {
            _orcamentoList.ChangeCheckState(false);
        }

        private void TsiMarcar_Click(object sender, EventArgs e)
        {
            _orcamentoList.ChangeCheckState(true);
        }

        private async void CancelamentoOrcamentoView_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.F5)
            {
                await _orcamentoList.LoadAsync();
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.M)
            {
                _orcamentoList.ChangeCheckState(true);
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                _orcamentoList.ChangeCheckState(false);
            }

        }

        private async void chk_Click(object sender, EventArgs e)
        {
            await _orcamentoList.LoadAsync();
        }

        #endregion
    }
}
