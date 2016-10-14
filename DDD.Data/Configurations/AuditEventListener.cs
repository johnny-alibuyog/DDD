using DDD.Core;
using DDD.Core.Models;
using NHibernate;
using NHibernate.Event;
using System;

namespace DDD.Data.Configurations
{
    internal class AuditEventListener : IPostInsertEventListener, IPostUpdateEventListener, IPostDeleteEventListener
    {
        public void OnPostDelete(PostDeleteEvent @event)
        {
            // TODO: 
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            var auditProvider = SessionFactoryProvider.AuditProvider;
            var session = @event.Session.GetSession(EntityMode.Poco);

            var entity = @event.Entity as IAuditable;
            if (entity == null)
                return;

            var userId = auditProvider.GetCurrentUserId();
            if (userId == null)
                return;

            entity.CreatedBy = session.Load<User>(userId);
            entity.CreatedOn = DateTime.Now;
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            var auditProvider = SessionFactoryProvider.AuditProvider;
            var session = @event.Session.GetSession(EntityMode.Poco);

            var entity = @event.Entity as IAuditable;
            if (entity == null)
                return;

            var currentUser = auditProvider.GetCurrentUserId();
            if (currentUser == null)
                return;

            entity.ModifiedBy = session.Load<User>(currentUser);
            entity.ModifiedOn = DateTime.Now;
        }
    }
}
