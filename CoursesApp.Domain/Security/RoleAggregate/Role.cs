using Common.Model;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public class Role : AggregateRoot, IDomainEntity
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public RoleStatus Status { get; private set; }
        public string Description { get; private set; }
        public List<User> Users { get; private set; }

        protected Role()
        {
            Users = new List<User>();
        }

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

        
    }
}
