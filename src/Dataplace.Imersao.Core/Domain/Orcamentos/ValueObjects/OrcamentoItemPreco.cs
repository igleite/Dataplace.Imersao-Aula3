using Dataplace.Imersao.Core.Domain.Exections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{

    public  class OrcamentoItemPreco
    {
        protected OrcamentoItemPreco() { }
        public decimal PrecoTabela { get; protected set; }
        public decimal PrecoVenda { get; protected set; }
        public decimal PercAltPreco { get; protected set; }
        internal bool IsValid()
        {
            return (PrecoTabela + (PrecoTabela * PercAltPreco / 100)) == PrecoVenda;
        }
    }

    public  class OrcamentoItemPrecoTotal : OrcamentoItemPreco
    {
        public OrcamentoItemPrecoTotal(decimal precoTabela, decimal precoVenda) 
        {
            if(precoTabela <= 0)
                throw new ValueLowerThanZeroDomainException(nameof(precoTabela));

            if (precoVenda <= 0)
                throw new ValueLowerThanZeroDomainException(nameof(precoVenda));

            this.PrecoTabela = precoTabela;
            this.PrecoVenda = precoVenda;
            this.PercAltPreco = (precoVenda * 100 / precoTabela) - 100;
        }
    }

    public  class OrcamentoItemPrecoPercentual : OrcamentoItemPreco
    {
        public OrcamentoItemPrecoPercentual(decimal precoTabela, decimal perAltPreco) 
        {
            if (precoTabela < 0)
                throw new ValueLowerThanZeroDomainException(nameof(precoTabela));

            this.PrecoTabela = precoTabela;
            this.PercAltPreco = perAltPreco;

            var decontoAcrescimo = precoTabela * Math.Abs(perAltPreco) / 100;

            if (perAltPreco < 0)
                this.PrecoVenda = this.PrecoTabela - decontoAcrescimo;
            else
                this.PrecoVenda = this.PrecoTabela + decontoAcrescimo;
        }
    }
}
