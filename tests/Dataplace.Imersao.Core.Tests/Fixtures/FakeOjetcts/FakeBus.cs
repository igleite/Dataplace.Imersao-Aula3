using Dataplace.Core.Domain.Bus;
using Dataplace.Core.Domain.Commands;
using Dataplace.Core.Domain.Events;

namespace Dataplace.Imersao.Core.Tests.Fixtures.FakeOjetcts
{
    public class FakeBus : IBus
    {
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
     
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
  
        }

        public TResult SendCommand<T, TResult>(T theCommand) where T : Command
        {
            return default(TResult);
        }
    }

}
