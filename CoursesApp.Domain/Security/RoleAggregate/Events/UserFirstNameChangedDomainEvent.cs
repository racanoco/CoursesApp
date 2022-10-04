using Common.DomainEvent;

namespace CoursesApp.Domain.Security.RoleAggregate.Events
{
    public class UserFirstNameChangedDomainEvent: IDomainEvent
    {
        #region PROPERTIES
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        #endregion

        #region BUILDER
        public UserFirstNameChangedDomainEvent(Guid id, string firstName)
        {
            Id = id;
            FirstName = firstName;
        }
        #endregion

    }
}
