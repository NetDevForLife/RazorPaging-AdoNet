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

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        [BindProperty]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome")]
        [BindProperty]
        public string Nome { get; set; }

        [Required(ErrorMessage = "L'indirizzo email è obbligatorio")]
        [EmailAddress(ErrorMessage = "L'indirizzo email deve avere un formato valido")]
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

            if (ModelState.IsValid)
            {
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
            else
            {
                return await OnGetAsync(userService);
            }
        }
    }
}