using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.DTO;
using WebApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace WebApp.Web.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly IFirebaseAuthService _authService;

        [BindProperty]
        public SignUpUserDto UserDto { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public SignUpModel(IFirebaseAuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {
            ErrorMessage = null; // —брос сообщени€ об ошибке
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var token = await _authService.SignUp(UserDto.Email, UserDto.Password);

                if (token is not null)
                {
                    HttpContext.Session.SetString("token", token);
                    return RedirectToPage("/Firestore/Index");
                }
                ErrorMessage = "Unknown error occurred during sign up.";
                return Page();
            }
            catch (Exception)
            {
                ErrorMessage = "Input error.";
                return Page();
            }
        }
    }
}
