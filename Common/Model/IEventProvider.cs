using Common.DomainEvent;

namespace Common.Model
{
    internal interface IEventProvider
    {
        #region METHODS
        IEnumerable<IDomainEvent> GetUncommittedDomainEvents();
        void MarkDomainEventsAsCommitted();
        #endregion

    }
}
