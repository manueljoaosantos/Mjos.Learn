using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Mjos.Learn.Core.Domain;

namespace Mjos.Learn.Infrastructure.EfCore
{
    public abstract class AppDbContextBase : DbContext, IDomainEventContext, IDbFacadeResolver
    {
        protected AppDbContextBase(DbContextOptions options) : base(options)
        {
        }

        public IEnumerable<EventBase> GetDomainEvents()
        {
            var domainEntities = ChangeTracker
                .Entries<EntityRootBase>()
                .Where(x =>
                    x.Entity.DomainEvents != null &&
                    x.Entity.DomainEvents.Any())
                .ToImmutableList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToImmutableList();

            domainEntities.ForEach(entity => entity.Entity.DomainEvents.Clear());

            return domainEvents;
        }
    }
}
