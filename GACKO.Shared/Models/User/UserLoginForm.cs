using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GACKO.Shared.Models.User
{
    public class UserLoginForm
    {
        public int Id { get; set; }
        [DisplayName("Login")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Username { get; set; }
        [DisplayName("Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
