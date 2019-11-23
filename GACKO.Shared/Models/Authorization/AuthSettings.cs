using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Models.Authorization
{
    public class AuthSettings
    {
        public string JwtSecret { get; set; }
        public int ExpireIn { get; set; }
    }
}
