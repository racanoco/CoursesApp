using Common.Model;
using CoursesApp.Domain.Security.RoleAggregate.Events;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public class Role : AggregateRoot, IDomainEntity
    {
        #region PROPERTIES
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public RoleStatus Status { get; private set; }
        public string Description { get; private set; }
        public List<User> Users { get; private set; }
        #endregion

        #region BUILDER
        protected Role()
        {
            Users = new List<User>();
        }
        #endregion

        #region METHODS
        public static Role CreateNew(string code, string name, string description)
        {
            Role entityRole = new()
            {
                Id = Guid.NewGuid(),
                Code = code,
                Name = name,
                Status = RoleStatus.Active,
                Description = description,
                Users = new List<User>()
            };

            return entityRole;
        }

        public void ChangeUserFirstName(Guid id, string firstName)
        {
            if (Users is null || Users.Count <= 0)
                return;

            User user = Users.Where(u => u.Id == id).SingleOrDefault();

            if (user is null)
                return;

            bool changed = user.ChangeFirstName(firstName);

            if (changed)
            {
                AddDomainEvent(new UserFirstNameChangedDomainEvent(id, firstName));

            }

        }
        #endregion


    }
}
