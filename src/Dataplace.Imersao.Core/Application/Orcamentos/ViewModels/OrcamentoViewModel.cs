using Dataplace.Core.Application.Contracts.Results;
using Dataplace.Core.Application.ViewModels.Contracts;
using Dataplace.Core.Mvvm;
using System;

namespace Dataplace.Imersao.Core.Application.Orcamentos.ViewModels
{
    public class OrcamentoViewModel : BindableBase, ISelectableViewModel, IResultViewModel, IEquatable<OrcamentoViewModel>
    {
        public IResult Result { get => _result; set => SetProperty(ref _result, value); }

        public string CdEmpresa { get; set; }
        public string CdFilial { get; set; }
        public int NumOrcamento { get; set; }
        public string CdCliente { get; set; }
        public string DsCliente { get; set; }
        public DateTime DtOrcamento { get; set; }
        public Decimal ValotTotal { get; set; }
        public int? DiasValidade { get; set; }
        public DateTime? DataValidade { get; set; }
        public string CdTabela { get; set; }
        public short? SqTabela { get; set; }
        public DateTime? DtFechamento { get; set; }
        public string CdVendedor { get; set; }
        public string Usuario { get; set; }
        public string Situacao { get; set; }




        public bool IsSelected { get; set; }

        private IResult _result;


        public bool Equals(OrcamentoViewModel other)
        {
            if (other == null)
                return false;

            return this.NumOrcamento.Equals(other.NumOrcamento);
        }
    }
}
