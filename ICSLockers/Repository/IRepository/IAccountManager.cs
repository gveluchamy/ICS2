using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public interface IAccountManager
    {
        Task<Task> CreateNewUser(ApplicationUser applicationUser);
        ApplicationUser FindUserByPassword(string password);
    }
}
