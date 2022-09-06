using Common.Model;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public interface IRoleRepository: IRepository<Role>
    {
        List<Role> GetByStatus(RoleStatus roleStatus);
        void AddUser(User user);
        Role GetByUserId(Guid userId);
        Role GetByUserCode(string userCode);
    }
}
