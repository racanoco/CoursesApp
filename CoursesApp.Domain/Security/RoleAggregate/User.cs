using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public class User : IDomainEntity
    {
        #region PROPERTIES
        public Guid Id { get; private set; }
        public Guid RoleId { get; private set; }
        public string Code { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public UserStatus Status { get; private set; }
        public string Description { get; private set; }
        public virtual Role Role { get; private set; }
        #endregion


        #region BUILDER
        protected User()
        {

        }
        #endregion

        #region METHODS
        public static User CreateNew(Guid roleId, string code, string firstName, string lastName, Address address, string description)
        {
            User entityUser = new()
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                Code = code,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Status = UserStatus.Active,
                Description = description
            };

            return entityUser;

        }

        internal bool ChangeFirstName(string firstName)
        {
            if(FirstName != firstName)
            {
                FirstName = firstName;
                return true;
            }
            return false;
        }

        public ValidationResult ValidateModel()
        {
            return new UserValidation().Validate(this);
        }
        #endregion




    }
}
