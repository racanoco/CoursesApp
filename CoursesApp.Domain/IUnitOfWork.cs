using Common.Model;
using CoursesApp.Domain.Security.RoleAggregate;

namespace CoursesApp.Domain
{
    public interface IUnitOfWork
    {
        IRoleRepository _roleRepository { get; }

        void Commit(AggregateRoot aggregateRoot);
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void Dispose();
    }
}
