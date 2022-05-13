using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.GB.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T item);
        Task<T> Update(int id, T item);
        Task<bool> Delete(int id);
    }   
}
