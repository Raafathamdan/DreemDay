using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.PaymentDTOs
{
    public class CreatePaymentDto
    {
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }
        public float? Balance { get; set; }
    }
}
