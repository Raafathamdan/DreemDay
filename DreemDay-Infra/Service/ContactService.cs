using DreemDay_Core.DTOs.ContactDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Infra.Service
{
  public class ContactService : IContactService
  {
    private readonly IContactRepos _contactRepos;

    public ContactService(IContactRepos contactRepos)
    {
      _contactRepos = contactRepos;
    }

    public async Task CreateContact(CreateContactDTO dTO)
    {
      var contact = new Contact
      {
        CreationDate = DateTime.Now,
        FullName = dTO.FullName,
        Email = dTO.Email,
        Status = ContactStatus.New,
        Subject = dTO.Subject,
        Message = dTO.Message,
        IsDeleted = false,
      };
      await _contactRepos.CreateContact(contact);
    }

    public async Task DeleteContact(int id)
    {
      var contact = await _contactRepos.GetContactById(id);
      if (contact != null)
      {
        contact.IsDeleted = true;
        await _contactRepos.UpdateContactStatus(contact);
      }
    }

    public async Task<List<ContactCardDTO>> GelAllContact()
    {
      var contacts = await _contactRepos.GelAllContact();
      return contacts
          .Where(c => c.IsDeleted == false)
          .Select(c => new ContactCardDTO
          {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Subject = c.Subject,
            Message = c.Message,
            Status = c.Status.ToString()
          })
          .ToList();
    }

    public async Task UpdateContactStatus(UpdateContactStatusDTO dTO)
    {
      var contact = await _contactRepos.GetContactById(dTO.Id);
      if (contact != null)
      {
        if (contact.Status == ContactStatus.New)
        {
          contact.Status = ContactStatus.Seen;
          await _contactRepos.UpdateContactStatus(contact);
        }
      }
    }
  }
}
