using System.Threading.Tasks;

namespace TimeSheets.GB.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T item);
        Task<T> Update(int id, T item);
        Task<T> Delete(int id);
    }   
}
