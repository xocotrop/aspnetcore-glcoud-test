using System.Collections.Generic;
using System.Threading.Tasks;
using Gcloud.Api.Repository.Context;
using Gcloud.Api.Repository.Contract;
using Gcloud.Api.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gcloud.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MAppContext _context;
        public UserRepository(MAppContext context)
        {
            _context = context;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();            
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(User user)
        {
            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}