﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.PaymentDTOs
{
    public class PaymentByIdDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float? Balance { get; set; }
    }
}
