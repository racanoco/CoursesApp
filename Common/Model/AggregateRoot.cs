using Common.DomainEvent;

namespace Common.Model
{
    public abstract class AggregateRoot: IEventProvider
    {
        #region GLOBAL VARIABLES
        private readonly List<IDomainEvent> _domainEvents;
        #endregion

        #region BUILDER
        protected AggregateRoot()
        {
            _domainEvents = new List<IDomainEvent>();
        }
        #endregion


        #region METHODS
        public IEnumerable<IDomainEvent> GetUncommittedDomainEvents()
        {
            return _domainEvents;
        }

        public void MarkDomainEventsAsCommitted()
        {
            _domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        #endregion

    }
}
