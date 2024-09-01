using DreemDay_Core.DTOs.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
  public interface IContactService
  {
    Task<List<ContactCardDTO>> GelAllContact();
    Task CreateContact(CreateContactDTO dTO);
    Task UpdateContactStatus(UpdateContactStatusDTO dTO);
    Task DeleteContact(int id);
  }
}
