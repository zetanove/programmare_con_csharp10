using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RegisterUserRazorPage.Pages
{
    public class RegisterUserModel : PageModel
    {
        //approccio 3
        //[BindProperty]
        //public string Email { get; set; }

        //[BindProperty]
        //public string Password { get; set; }

        //approccio4
        [BindProperty]
        public RegisterData Register { get; set; }

        public void OnGet()
        {
            ViewData["message"] = "Inserisci i dati richiesti";
        }

        ////approccio 1
        //public void OnPost()
        //{
        //    var email = Request.Form["Email"];
        //    var password = Request.Form["Password"];
        //    ViewData["message"] = $"Ti sei registrato con email {email}!";
        //}

        ////approccio 2
        //public void OnPost(string email, string password)
        //{            
        //    ViewData["message"] = $"Ti sei registrato con email {email}!";
        //}

        ////approccio 3
        //public void OnPost()
        //{
        //    ViewData["message"] = $"Ti sei registrato con email {Email}!";
        //}

        //approccio 4
        public void OnPost()
        {
            ViewData["message"] = $"Ti sei registrato con email {Register.Email}!";
        }
    }

    public class RegisterData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
