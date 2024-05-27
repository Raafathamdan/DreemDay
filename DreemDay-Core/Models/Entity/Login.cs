using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class Login : MainEntity
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
