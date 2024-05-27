using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.ServiceDTOs
{
    public class CreateServiceDto
    {
        public int ServiceProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public bool isHaveDiscount { get; set; }
        public double DiscountAmount { get; set; }
        public double PriceAfterDiscount { get; set; }
    }
}
