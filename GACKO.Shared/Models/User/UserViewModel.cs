using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Models.User
{
    public class UserViewModel : GackoBaseViewModel
    {
        public bool IsSuccess { get; set; } = false;
        public UserLoginForm UserloginForm { get; set;  }
    }
}
