using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
namespace API.Interfaces
{
    public interface IUserRepository
    {
        void update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUserAsync();
        Task<AppUser> GetElementByIdAsync(int id);
        Task<AppUser> GetElementByUsernameAsync(string username);
    }
}