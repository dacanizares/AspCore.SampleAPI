using SampleAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IUserQueries
    {
        Task<List<User>> FindAllAsync();
        Task<User> FindByUsernameAsync(string username);
    }
}
