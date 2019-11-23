using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Models.Authorization
{
    public class Authenticate
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
