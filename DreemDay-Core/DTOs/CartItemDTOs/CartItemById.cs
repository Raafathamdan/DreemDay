using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.CartItemDTOs
{
    public class CartItemById
    {
        public int    Id { get; set; }
        public int    userId { get; set; }

        public int    ServiceId { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }

        public string ServiceDescription { get; set; }


        public int    CartId { get; set; }
        public bool CartActivate { get; set; }

        public int    Quantity { get; set; }

        public string  CreationDate { get; set; }
        public string? ModifiedDate { get; set; }
        public bool    IsDeleted { get; set; }
    }
}
