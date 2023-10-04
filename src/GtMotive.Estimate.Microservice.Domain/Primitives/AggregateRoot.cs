using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Domain.Primitives
{
    /// <summary>
    /// AggregateRoot.
    /// </summary>
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new();

        /// <summary>
        /// GetDomainEvents.
        /// </summary>
        /// <returns>List of the Domain Events.</returns>
        public ICollection<DomainEvent> GetDomainEvents()
        {
            return _domainEvents;
        }

        /// <summary>
        /// Raise Events.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
