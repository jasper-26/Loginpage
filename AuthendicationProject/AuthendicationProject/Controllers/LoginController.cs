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
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly LoginService _booksService;

        public LoginController(LoginService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<UserDetailModel>> Get() =>
            await _booksService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromForm] UserDetailModel objuserlogin)
        {
            var book = await _booksService.GetAsync(objuserlogin.Username, objuserlogin.Password);

            if (book != null)
            {
                return RedirectToAction("Privacy", "Home", new { status = "Login Successful" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { status = "No user found" });
            }

        }
    }
}

