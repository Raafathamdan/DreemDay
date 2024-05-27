using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.AuthDTOs
{
    public class ResetDto
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public int Email { get; set; }


    }
}
