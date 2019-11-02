﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}