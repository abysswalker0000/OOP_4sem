using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Interfaces
{
    public interface IFirebaseAuthService
    {
        Task<string?> SignUp(string email, string password);
        Task<string?> Login(string email, string password);
        void SignOut();
    }
}
