using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.DTOs.ContactDTOs
{
  public class UpdateContactStatusDTO
  {
    public int Id { get; set; }
    public ContactStatus Status {  get; set; } 
  }
}
