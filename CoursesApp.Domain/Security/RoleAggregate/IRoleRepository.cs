using Common.Model;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public interface IRoleRepository: IRepository<Role>
    {

        #region GET
        List<Role> GetByStatus(RoleStatus roleStatus);
        Role GetByUserId(Guid userId);
        Role GetByUserCode(string userCode);
        #endregion

        #region POST
        void AddUser(User user);
        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion



        
    }
}
