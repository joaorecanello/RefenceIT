using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LightSwitchApplication.Models
{

    public class UserDTO
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsOnline { get; set; }

        [Display(Name = "lembrar?")]
        public bool RememberMe { get; set; }

    }

    public class ChangePasswordDTO
    {

        [Display(Name = "Senha Antiga")]
        public string OldPassword { get; set; }
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }
        [Display(Name = "Confirmar Senha")]
        public string ConfirmPassword { get; set; }

    }

}