using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TimeSheets.GB.DAL.Entities;
using TimeSheets.GB.DAL.Interfaces;

namespace TimeSheets.GB.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TimeSheetsDbContext _context;

        public UserRepository(TimeSheetsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(UserEntity item)
        {
            await _context.Users.AddAsync(item);
            return await Commit();
        }


        public async Task<bool> Delete(int id)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(u => u.Id == id));
            return await Commit();
        }

        public async Task<UserEntity> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IReadOnlyList<UserEntity>> GetAll()
        {
            return new List<UserEntity>();
        }

        public async Task<IReadOnlyList<UserEntity>> GetByName(string name)
        {
            try
            {
                return await _context.Users.Where(u => u.Name == name).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> Update(int id, UserEntity item)
        {
            return Task.FromResult(true);
        }

        private async Task<bool> Commit()
        {
            var count = await _context.SaveChangesAsync();
            return count > 0;
        }
    }
}
