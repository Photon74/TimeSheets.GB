using System.Collections.Generic;
using System.Threading.Tasks;

using TimeSheets.GB.DAL.Entities;

namespace TimeSheets.GB.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IReadOnlyList<UserEntity>> GetByName(string name);
    }
}
