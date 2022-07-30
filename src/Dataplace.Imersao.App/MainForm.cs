using Dataplace.Imersao.Presentation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataplace.Imersao.App
{
    public partial class MainForm : dpLibrary05.fMNU_Principal
    {
        public MainForm()
        {
            InitializeComponent();

            AddMenu(new ToolStripMenuItem("Relatório de teste", null, (object sender, EventArgs e) => {
                Dataplace.Core.win.Views.Managers.ViewManager.ShowViewOnForm<TesteReportView>();
            }), TipoMenuEnun.Relatorio);

            AddMenu(new ToolStripMenuItem("Cancelamento de orçamento em aberto", null, (object sender, EventArgs e) => {
                Dataplace.Core.win.Views.Managers.ViewManager.ShowViewOnForm<CancelamentoOrcamentoView>();
            }), TipoMenuEnun.Ferramenta);
        }
    }
}
