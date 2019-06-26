using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Company.WebApplication1.Pages.Forms
{
    public class GeneralModel : PageModel
    {
        public class Form1Model
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email address")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "User password")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Upload file", Description = "Example model description text here.")]
            public IFormFile File { get; set; }

            [Required]
            [BindProperty]
            public bool IsCheck { get; set; }
        }

        public class Form2Model
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "User")]
            public string Password { get; set; }

            [Required]
            [BindProperty]
            public bool IsCheck { get; set; }
        }

       

        [BindProperty]
        public Form1Model Form1 { get; set; }

        [BindProperty]
        public Form2Model Form2 { get; set; }

        public void OnGet()
        {
            Form1 = new Form1Model
            {
                Email = "mail@example.com",
                IsCheck = true,
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = $"Error!";
                return Page();
            }

            TempData["StatusMessage"] = "Your profile has been updated";
            return RedirectToPage();
        }

        public IActionResult OnPostForm2()
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = $"Error!";
                return Page();
            }

            TempData["StatusMessage"] = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}