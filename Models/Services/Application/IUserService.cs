using System.Threading.Tasks;
using RazorPagingAdoNet.Models.InputModels;
using RazorPagingAdoNet.Models.ViewModels;

namespace RazorPagingAdoNet.Models.Services.Application
{
    public interface IUserService
    {
        Task<ListViewModel<UserViewModel>> GetUsersAsync();
        Task<bool> CreateUserAsync(UserInputModel input);
    }
}