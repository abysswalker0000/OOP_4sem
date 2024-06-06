using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.Interfaces;

namespace WebApp.Web.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public LogoutModel(IFirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }   

        public IActionResult OnGet()
        {
            _firebaseAuthService.SignOut();
            HttpContext.Session.Remove("token");
            return Redirect("Index");
        }
    }
}
