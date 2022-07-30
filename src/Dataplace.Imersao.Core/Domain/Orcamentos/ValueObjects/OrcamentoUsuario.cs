using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoUsuario
    {
        // use orm
        protected OrcamentoUsuario() { }
        public OrcamentoUsuario(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }

        internal bool IsValid()
        {
            return (UserName.Trim().Length > 0);
        }
    }
}
