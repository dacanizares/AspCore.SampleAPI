using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public interface IUserBehavior
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}