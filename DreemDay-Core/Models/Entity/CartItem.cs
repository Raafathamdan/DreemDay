using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CartId { get; set; }
        public int  Quantity { get; set; }
    }
}
