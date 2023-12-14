using LibrarySystem.BL.DTOS.UserDTO;
using LibrarySystem.BL.Manager.UserManagers;
using LibrarySystem.DAL.Enums;
using LibrarySystem.DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUsers()
        {
            return View(userManager.GetAll());
        }

        public  ActionResult GetUserByID(int id)
        {
            return View(userManager.GetById(id));
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserWriteDTO userWriteDTO)
        {
            if (ModelState.IsValid)
            {
                var passwordEncrypt = EncodePasswordToBase64(userWriteDTO.UserPassword);
                userWriteDTO.UserPassword = passwordEncrypt;
                var result = userManager.Insert(userWriteDTO);
                if (result != null)
                {
                    return RedirectToAction(nameof(Register));
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var passwordEncrypt = EncodePasswordToBase64(userLoginDto.UserPassword);
                var user=  userManager.Login(userLoginDto.UserName, passwordEncrypt);
                if (user!=null)
                {
                    //HttpContext.Session.SetString("UserID", user.UserID.ToString());
                    //HttpContext.Session.GetString("UserID");
;
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.UserType.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    return RedirectToAction("GetAllBooks","Book");
                }
                ModelState.AddModelError("", "Error In UserName Or Password");
            }

            return View(userLoginDto);
        }
        public  string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {
            return View(userManager.GetById(id));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserUpdateDTO UserUpdateDTO)
        {
            if (ModelState.IsValid && id == UserUpdateDTO.UserID)
            {
                userManager.Update(UserUpdateDTO);
                return RedirectToAction(nameof(GetAllUsers));
            }
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                userManager.Delete(id);
                return RedirectToAction(nameof(GetAllUsers));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");
        }

    }
}
