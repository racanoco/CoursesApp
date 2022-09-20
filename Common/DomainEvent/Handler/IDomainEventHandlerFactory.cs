﻿namespace Common.DomainEvent.Handler
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetHandlers<T>() where T : IDomainEvent;
    }
}
