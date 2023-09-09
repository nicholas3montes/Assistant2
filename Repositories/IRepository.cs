using Assistant2.Models;

namespace Assistant2.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
    }
}
