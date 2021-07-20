using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagingAdoNet.Models.Services.Application;
using RazorPagingAdoNet.Models.ViewModels;

namespace RazorPagingAdoNet.Pages
{
    public class UsersModel : PageModel
    {
        public ListViewModel<UserViewModel> Utente = new();

        public async Task<IActionResult> OnGetAsync([FromServices] IUserService userService)
        {
            try
            {
                Utente = await userService.GetUsersAsync();
                return Page();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}