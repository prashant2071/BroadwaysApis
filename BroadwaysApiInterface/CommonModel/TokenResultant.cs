using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.CommonModel
{
    public class TokenResultant
    {
        public string UserName { get; set; }


        public string Role { get; set; }


        public string AccessToken { get; set; }


        public string RefreshToken { get; set; }
    }
}
