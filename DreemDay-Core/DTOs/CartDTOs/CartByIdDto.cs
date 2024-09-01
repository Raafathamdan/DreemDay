using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.CartDTOs
{
    public class CartByIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public string CreationDate { get; set; }
        public string? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
