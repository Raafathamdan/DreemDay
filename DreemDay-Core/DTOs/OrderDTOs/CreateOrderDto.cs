using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.DTOs.OrderDTOs
{
  public class CreateOrderDto
  {
    public int CartId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Note { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Code { get; set; }
    public string CardNumber { get; set; }
    public string CardHolder { get; set; }
    public decimal Price { get; set; } 
  }

}

