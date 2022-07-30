using Dataplace.Imersao.Core.Domain.Exections;
using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoValidade
    {
        // uso orm
        protected OrcamentoValidade() { }
        public OrcamentoValidade(Orcamento orcamento, int dias)
        {
            if(dias < 0)
                throw new ValueLowerThanZeroDomainException(nameof(dias));

            Dias = dias;
            Data = orcamento.DtOrcamento.AddDays(dias).Date;

        }

        public DateTime Data { get; private set; }
        public int Dias { get; private set; }

        public bool IsValid()
        {
            if (Dias == 0 || Data == default(DateTime))
                return false;
            else
                return true;
        }
    }
}
