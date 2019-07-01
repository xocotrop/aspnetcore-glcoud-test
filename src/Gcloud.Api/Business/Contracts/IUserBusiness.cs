using System.Collections.Generic;
using System.Threading.Tasks;
using Gcloud.Api.Repository.Entities;

namespace Gcloud.Api.Business.Contracts
{
    public interface IUserBusiness
    {
        Task AddUser(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
        Task Remove(User user);
        Task Edit(User user);

    }
}