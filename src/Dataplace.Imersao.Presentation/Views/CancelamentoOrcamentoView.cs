using Dataplace.Core.Domain.Localization.Messages.Extensions;
using Dataplace.Core.win.Controls.List.Behaviors;
using Dataplace.Core.win.Controls.List.Behaviors.Contracts;
using Dataplace.Core.win.Controls.List.Configurations;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
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
    public partial class CancelamentoOrcamentoView : dpLibrary05.Infrastructure.UserControls.ucSymGen_ToolDialog
    {
        #region fields
        private IListBehavior<OrcamentoViewModel, OrcamentoQuery> _orcamentoList;
        #endregion

        #region constructors
        public CancelamentoOrcamentoView()
        {
            InitializeComponent();

            _orcamentoList = new C1TrueDBGridListBehavior<OrcamentoViewModel, OrcamentoQuery>(gridOrcamento)
                .WithConfiguration(GetConfiguration());

            this.ToolConfiguration += CancelamentoOrcamentoView_ToolConfiguration;

        }
        #endregion

        #region tool events
        private void CancelamentoOrcamentoView_ToolConfiguration(object sender, ToolConfigurationEventArgs e)
        {
            // definições iniciais do projeto
            // item seguraça
            // engine code

            this.Text = "Cancelamento de orçamento";
            e.SecurityIdList.Add(467);
        }
        #endregion

        #region list events
        private ViewModelListBuilder<OrcamentoViewModel> GetConfiguration()
        {
            var configuration = new ViewModelListBuilder<OrcamentoViewModel>();
            
            configuration.WithQuery<OrcamentoQuery>(() => new OrcamentoQuery() { Situacao = Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Aberto });



            configuration.Ignore(x => x.CdEmpresa);
            configuration.Ignore(x => x.CdFilial);
            configuration.Ignore(x => x.SqTabela);
            configuration.Ignore(x => x.CdTabela);
            configuration.Ignore(x => x.DtFechamento);
            configuration.Ignore(x => x.CdVendedor);
            configuration.Ignore(x => x.Usuario);
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

        #endregion

        #region contol events
        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            await _orcamentoList.LoadAsync();
        }
        #endregion
    }
}
