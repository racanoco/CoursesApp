using System.Linq.Expressions;

namespace Common.Model
{
    /// <summary>
    /// Generic repository interface that can be used by any type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : AggregateRoot
    {
        /// <summary>
        /// Methods of persistence and access to the database.
        /// </summary>        


        #region GET
        T GetById(Guid id);

        /// <summary>
        /// Get record by any field
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> match);

        /// <summary>
        /// Get multiple records by any field
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        #endregion

        #region POST
        void Add(T entity);
        #endregion

        #region PUT
        void Update(T entity);
        #endregion

        #region DELETE
        void Delete(Guid id);
        #endregion









    }
}
