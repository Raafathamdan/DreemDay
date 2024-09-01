using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.DTOs.ContactDTOs
{
  public class ContactCardDTO
  {
    public int    Id       { get; set; }
    public string FullName { get; set; }
    public string Email    { get; set; }
    public string Subject  { get; set; }
    public string Message  { get; set; }
    public string Status  { get; set; }
  }
}
