using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.Models.Entity
{
    public class Order : MainEntity
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
    }
}
