using System.Threading.Tasks;
using RazorPagingAdoNet.Models.ViewModels;

namespace RazorPagingAdoNet.Models.Services.Application
{
    public interface IUserService
    {
        Task<ListViewModel<UserViewModel>> GetUsersAsync();
    }
}