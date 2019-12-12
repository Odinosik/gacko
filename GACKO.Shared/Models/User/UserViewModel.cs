using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Models.User
{
    /// <summary>
    /// User View Model
    /// </summary>
    public class UserViewModel : GackoBaseViewModel
    {
        public bool IsSuccess { get; set; } = false;
        public UserLoginForm UserloginForm { get; set;  }
    }
}
