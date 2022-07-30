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
    public partial class TotalCondicaoPagamentoView : dpLibrary05.Infrastructure.UserControls.ucSymGen_ReportDialog
    {

        private const string _name = "Totalização de Condições de Pagamento";
        private const int _itemSeg = 649;
        private const int _reportId = 1006338;

        public TotalCondicaoPagamentoView()
        {
            InitializeComponent();

            this.ReportConfiguration += TesteReportView_ReportConfiguration;
            this.BeforeLoadReport += TesteReportView_BeforeLoadReport;
            this.AfterLoadReport += TesteReportView_AfterLoadReport;
            this.LoadReport += TesteReportView_LoadReport;
        }

        private void TesteReportView_ReportConfiguration(object sender, ReportConfigurationEventArgs e)
        {
            // configuraçõe iniciais da tela
            // item de segurança
            // id do report,

            this.Text = _name;
            e.ReportList.Add(_reportId,
                           new dpLibrary05.SymphonyReport.clsSymReport.ReportData(true)
                           {
                               Id = _reportId,
                               ItemSeg = _itemSeg.ToString(),
                               Name = _name
                           });
            e.SecurityIdList.Add(_itemSeg);

        }

        private void TesteReportView_BeforeLoadReport(object sender, BeforeLoadReportEventArgs e)
        {
            // validações para exibir report
            // item de segurança
            // preenchimento dos controles

        }

        private void TesteReportView_LoadReport(object sender, LoadReportEventArgs e)
        {
            // definir o report a ser executado
            e.ReportData = ReportList[_reportId];

            // passagem dos parâmetros para o report
            //e.ReportData.Parametros.Items.Add("cdEmpresa", dpLibrary05.mGenerico.SymPRM.cdempresa);
            //e.ReportData.Parametros.Items.Add("cdFilial", dpLibrary05.mGenerico.SymPRM.cdfilial);
        }

        private void TesteReportView_AfterLoadReport(object sender, AfterLoadReportEventArgs e)
        {
            // ...
        }


    }
}
