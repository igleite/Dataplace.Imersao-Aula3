using Dataplace.Core.Application.Contracts.Results;
using Dataplace.Core.Application.Services.Results;
using Dataplace.Core.Domain.Commands;
using Dataplace.Core.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Tests.Fixtures.FakeOjetcts
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public int BeginTransaction()
        {
            return 1;
        }

        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public CommandResponse Commit(int hashCodeTransaction)
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
    
        }

        public void Rollback()
        {
         
        }

        public void Rollback(int hashCodeTransaction)
        {
       
        }
    }

}
