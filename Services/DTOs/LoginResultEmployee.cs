using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDemoProject.Services
{
    public class LoginResultEmployee
    {
        public string message { get; set; }
        public string Token { get; set; }
        public LoginUserAdmin User { get; set; }
    }
}
