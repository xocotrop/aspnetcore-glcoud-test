using System.Collections.Generic;
using System.Threading.Tasks;
using Gcloud.Api.Business.Contracts;
using Gcloud.Api.Repository.Contract;
using Gcloud.Api.Repository.Entities;

namespace Gcloud.Api.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task Edit(User user)
        {
            await _userRepository.Edit(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task Remove(User user)
        {
            await _userRepository.Delete(user);
        }
    }
}