using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.CartDTOs
{
    public class CreateCartDto
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
