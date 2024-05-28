using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.CartItemDTOs
{
    public class CartItemById
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CartId { get; set; }
        public string CreationDate { get; set; }
        public string? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
