using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{

    public class OrcamentoTabelaPreco
    {

        // uso orm
        protected OrcamentoTabelaPreco() { }
        public OrcamentoTabelaPreco(string cdTabela, short sqTabela)
        {
            CdTabela = cdTabela;
            SqTabela = sqTabela;
        }
        public string CdTabela { get; private set; }
        public short SqTabela { get; private  set; }

        internal bool IsValid()
        {
            return (CdTabela.Trim().Length > 0 && SqTabela > -1);
        }
    }
}
