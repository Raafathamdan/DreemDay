﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.DTOs.OrderDTOs
{
    public class OrderByIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Date { get; set; }
        public OrderStatus Status { get; set; }
        public string CreationDate { get; set; }
        public string? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
