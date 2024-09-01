using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.CartItemDTOs
{
    public class CreateCartItemDto
    {

        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
