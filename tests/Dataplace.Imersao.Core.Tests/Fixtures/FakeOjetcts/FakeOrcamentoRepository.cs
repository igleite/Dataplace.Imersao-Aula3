using Dataplace.Imersao.Core.Domain.Orcamentos;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Tests.Fixtures.FakeOjetcts
{
    public class FakeOrcamentoRepository : IOrcamentoRepository
    {

        int? IOrcamentoRepository.AdicionarOrcamento(Orcamento entity)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarOrcamento(Orcamento entity)
        {
            return true;
        }

        public bool ExcluirOrcamento(Orcamento entity)
        {
            return true;
        }

        public Orcamento ObterOrcamento(string cdEmpresa, string cdFilail, int numOrcamento)
        {
            throw new NotImplementedException();
        }

        public Orcamento ObterOrcamentoComItems(string cdEmpresa, string cdFilail, int numOrcamento)
        {
            throw new NotImplementedException();
        }

        public int? AdicionarItem(OrcamentoItem entity)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarItem(OrcamentoItem entity)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirItem(OrcamentoItem entity)
        {
            throw new NotImplementedException();
        }

        public OrcamentoItem ObterItem(string cdEmpresa, string cdFilail, int numOrcamento, int seq)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrcamentoItem> ObterItems(string cdEmpresa, string cdFilial, int numOrcamento)
        {
            throw new NotImplementedException();
        }
    }
}
