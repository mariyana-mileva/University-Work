using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer;
using DataAccessLayer.CustomerDBs;
using Entities;
namespace Website.Pages.Login
{
    public class RegisterModel : PageModel
    {
        ICustomerAuthorization customerAuthorization = new CustomerAuthorizationDB();

        [BindProperty]
        [Required(ErrorMessage = "Invalid email address")]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your first name")]
        public string fname { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter your last name")]
        public string lname { get; set; }
        
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password")]
        public string password { get; set; }
       
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please repeat the password")]
        public string repPassword { get; set; }

        public string msg { get; set; } 

        public void OnGet()
        {
        }

        public IActionResult RegisterOnPost()
        {
            if(ModelState.IsValid)
            {
                if(customerAuthorization.checkForRepeatingEmail(this.email) != true && customerAuthorization.checkForRepeatingEmail(this.email) is not null)
                {
                    if(this.password == this.repPassword)
                    {
                        Customer customer = customerAuthorization.RegisterCustomer(this.email, this.fname, this.lname, this.password);
                        return RedirectToPage("Login");
                    }
                    else
                    {
                        this.msg = "Passwords does not match!";
                        return Page();
                    }

                }
                else if(customerAuthorization.checkForRepeatingEmail(this.email) == true)
                {
                    this.msg = "There is already an account with this email!";
                    return Page();
                }
                else
                {
                    this.msg = "An error occured!";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
