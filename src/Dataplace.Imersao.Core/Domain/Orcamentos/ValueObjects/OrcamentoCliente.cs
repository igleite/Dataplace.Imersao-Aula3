using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoCliente
    {
        // uso orm
        protected OrcamentoCliente() { }
        public OrcamentoCliente(string codigo)
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
