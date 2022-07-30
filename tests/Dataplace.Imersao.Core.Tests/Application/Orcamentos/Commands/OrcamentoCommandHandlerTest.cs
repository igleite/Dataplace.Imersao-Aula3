using Dataplace.Core.Domain.Notifications;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Tests.Fixtures;
using Dataplace.Imersao.Core.Tests.Fixtures.FakeOjetcts;
using Xunit;

namespace Dataplace.Imersao.Core.Tests.Application.Orcamentos.Commands
{

    [Collection(nameof(OrcamentoCollection))]
    public class OrcamentoCommandHandlerTest
    {
        private readonly OrcamentoFixture _fixture;

        public OrcamentoCommandHandlerTest(OrcamentoFixture fixture)
        {
            _fixture = fixture;
        }


        //[Fact]
        //public void AdicionarOrcamentoDeveResultarEmSucesso()
        //{
        //    // arrange
        //    var uow = new FakeUnitOfWork();
        //    var bus = new FakeBus();
        //   // var notification = new FakeDonainNotification();
        //    var notification = new DomainNotificationHandler();
        //    var repository = new FakeOrcamentoRepository();
        //    var handler = new OrcamentoCommandHandler(uow, bus, notification, repository);

        //    var item = new OrcamentoViewModel();
        //    var command = new AdicionarOrcamentoCommand(item);

        //    // act 
        //    handler.Handle(command);

        //    // assert
        //    Assert.False(notification.HasNotifications());
        //}

    }
}
