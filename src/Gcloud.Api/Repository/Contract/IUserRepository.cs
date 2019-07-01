using System.Collections.Generic;
using System.Threading.Tasks;
using Gcloud.Api.Repository.Entities;

namespace Gcloud.Api.Repository.Contract
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAsync();
        Task Add(User user);
        Task Edit(User user);
        Task Delete(User user);
    }
}