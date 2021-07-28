using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagingAdoNet.Models.InputModels;
using RazorPagingAdoNet.Models.Services.Application;
using RazorPagingAdoNet.Models.ViewModels;

namespace RazorPagingAdoNet.Pages
{
    public class UsersModel : PageModel
    {
        public ListViewModel<UserViewModel> Utente = new();

        [Display(Name = "Cognome")]
        [BindProperty]
        public string Cognome { get; set; }

        [Display(Name = "Nome")]
        [BindProperty]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [BindProperty]
        public string Email { get; set; }

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

        public async Task<IActionResult> OnPostAsync([FromServices] IUserService userService)
        {
            UserInputModel input = new();

            input.Cognome = Cognome;
            input.Nome = Nome;
            input.Email = Email;

            bool result = await userService.CreateUserAsync(input);
            
            if (result)
            {
                return await OnGetAsync(userService);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}