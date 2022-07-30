using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoVendedor
    {
        // uso orm
        protected OrcamentoVendedor() { }
        public OrcamentoVendedor(string codigo)
        {
            Codigo = codigo;
        }
        public string Codigo { get; private set; }

        internal bool IsValid()
        {
            return (Codigo.Trim().Length > 0);
        }
    }
}
