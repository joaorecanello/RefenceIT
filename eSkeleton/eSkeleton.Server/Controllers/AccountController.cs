using LightSwitchApplication.Models;
using Microsoft.LightSwitch.Security.ServerGenerated.Implementation;
using Microsoft.LightSwitch.Server;
using System;
using System.Configuration;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace LightSwitchApplication.Controllers
{

    public class AccountController : Controller
    {

        // Register - Create a new user
        public ActionResult Register()
        {
            return
                View(new UserDTO());
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {

            try
            {

                var UserName = collection["UserName"];
                var Password = collection["Password"];
                var Email = collection["Email"];

                if (UserName == "")
                {

                    throw new Exception("No UserName");

                }

                if (Password == "")
                {

                    throw new Exception("No Password");

                }

                // Keep our UserName as LowerCase
                UserName = UserName.ToLower();

                // Create LightSwitch user
                MembershipUser objMembershipUser = Membership.CreateUser(UserName, Password, Email);

                // Log User in
                // Create a new instance of the LightSwitch Authentication Service
                using (var authService = new AuthenticationService())
                {

                    var LoggedInUser = authService.Login(
                        UserName,
                        Password,
                        false,
                        null);

                    // Successful login?  If so, return the user
                    if (LoggedInUser != null)
                    {

                        return Redirect("~/Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Login failed.");
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(
                    string.Empty, "Error: " + ex);

                return View();

            }

        }

        // ChangePassword - Change the password of an existing user
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordDTO());

        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(FormCollection collection)
        {

            try
            {

                using (var authService = new AuthenticationService())
                {

                    if (collection["NewPassword"] != collection["ConfirmPassword"])
                    {

                        throw new Exception("New Password and Confirm Password must match");

                    }

                    if (!Membership.GetUser()

                        .ChangePassword(collection["OldPassword"], collection["NewPassword"]))
                    {

                        throw new Exception("Password change failed.");

                    }

                    return Redirect("~/Home");

                }

            }

            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Error: " + ex);

                return View();

            }

        }

        // Login - Log a user in, return authentication cookie
        public ActionResult Login()
        {

            if (Request.IsAuthenticated)
            {

                return
                    Redirect("~/App");

            }
            else
            {

                return
                    View(new UserDTO());

            }

        }

        [HttpPost]
        public JsonResult Login(FormCollection userform)
        {
            try
            {

             // Create a new instance of the LightSwitch Authentication Service
                using (var authService = new AuthenticationService())
                {

                    // Log User in
                    var user = authService.Login(
                        userform["UserName"].ToLower(),
                        userform["Password"],
                        Convert.ToBoolean(userform["RememberMe"]), null);

                    // Successful login?  If so, return the user
                    if (user != null)
                    {

                        return
                            Json(new { userValidated = true, redirectUrl = "" });

                    }
                    else
                    {

                        return
                            Json(new { userValidated = false, error = "Opa, algo deu errado. Verifique o nome de usuário e senha." });

                    }

                }

            }
            catch (Exception ex)
            {

                return
                    Json(new { userValidated = false, error = ex.Message });

            }

        }

        // LogOff - Clears the cookie, logging a user out of the system
        public ActionResult LogOff()
        {

            // Create a new instance of the LightSwitch Authentication Service
            using (var authService = new AuthenticationService())
            {

                FormsAuthentication.SignOut();
                var user = authService.Logout();

                return
                    Redirect("~/Account/Login");

            }

        }

    }
}