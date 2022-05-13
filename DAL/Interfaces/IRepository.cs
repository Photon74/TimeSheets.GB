using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.GB.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T item);
        Task<bool> Update(int id, T item);
        Task<bool> Delete(int id);
    }
}
