using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.AuthDTOs
{
    public class SignUpDto
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
