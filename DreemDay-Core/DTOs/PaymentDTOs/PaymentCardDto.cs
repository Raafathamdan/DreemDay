using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.PaymentDTOs
{
    public class PaymentCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal? Balance { get; set; }
    }
}
