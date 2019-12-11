using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GACKO.Shared.Models.User
{
    /// <summary>
    /// User Register Form
    /// </summary>
    public class UserRegisterForm
    {
        [DisplayName("Imie")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Email { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string UserName { get; set; }

        [DisplayName("Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Password { get; set; }
        public string RegisterErrorMessage { get; set; }
    }
}
