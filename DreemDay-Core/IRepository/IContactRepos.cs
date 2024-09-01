using DreemDay_Core.DTOs.ContactDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
  public interface IContactRepos
  {
    Task<List<Contact>> GelAllContact();
    Task CreateContact(Contact contact);
    Task UpdateContactStatus(Contact contact);
    Task<Contact> GetContactById(int id);
    Task DeleteContact(int id);

  }
}
