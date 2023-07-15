using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginProject.Models;
using LoginProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginProject.Controllers
{
    [ApiController]
    [Route("api/signup")]
    public class SignupController : Controller
    {
        private readonly LoginService _booksService;

        public SignupController(LoginService booksService) =>
            _booksService = booksService;


        [HttpPost]
        public async Task<IActionResult> SignupUser([FromForm] UserDetailModel objuserlogin)
        {
            // cehck if the user already exist

            var book = await _booksService.GetAsync(objuserlogin.Username, objuserlogin.Password);

            if(book != null)
            {
                return RedirectToAction("Signup", "Home", new { status = "User already exist" });
            }
            else
            {

                await _booksService.CreateAsync(objuserlogin);
                return RedirectToAction("Index", "Home", new { status = "Register Successfull" });

            }

        }
    }
    
}

