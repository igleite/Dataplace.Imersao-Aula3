using Dataplace.Core.win.Controls.List.Behaviors;
using Dataplace.Core.win.Controls.List.Behaviors.Contracts;
using Dataplace.Core.win.Controls.List.Configurations;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
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

        private IListBehavior<OrcamentoViewModel, OrcamentoQuery> _orcamentoList;
        public CancelamentoOrcamentoView()
        {
            InitializeComponent();

            _orcamentoList = new C1TrueDBGridListBehavior<OrcamentoViewModel, OrcamentoQuery>(gridOrcamento)
                .WithConfiguration(GetConfiguration());

        }

        private ViewModelListBuilder<OrcamentoViewModel> GetConfiguration()
        {
            var configuration = new ViewModelListBuilder<OrcamentoViewModel>();

            configuration.WithQuery<OrcamentoQuery>( () => new OrcamentoQuery() { Situacao = Core.Domain.Orcamentos.Enums.OrcamentoStatusEnum.Aberto });

            return configuration;
        }



        #region contol events
        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            await _orcamentoList.LoadAsync();
        }
        #endregion
    }
}
