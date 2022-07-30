using Dataplace.Core.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Tests.Fixtures.FakeOjetcts
{
    public class FakeDonainNotification : IDomainNotificationHandler<DomainNotification>
    {
        public event DomainNotificationEventHandler<DomainNotification> Notifications;

        public List<DomainNotification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(DomainNotification message)
        {
            throw new NotImplementedException();
        }

        public bool HasNotifications()
        {
            return false;
        }

        public void ResetNotifications()
        {
            throw new NotImplementedException();
        }
    }
}
