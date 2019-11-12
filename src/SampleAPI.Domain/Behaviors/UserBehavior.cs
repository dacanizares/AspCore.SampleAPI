using SampleAPI.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class UserBehavior : IUserBehavior
    {
        protected readonly IUserRepository _repository;

        public UserBehavior(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUserAsync(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            user.IsActive = true;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            await _repository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            user.UpdatedAt = DateTime.Now;
            await _repository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            await _repository.DeleteUserAsync(user);
        }
    }
}
