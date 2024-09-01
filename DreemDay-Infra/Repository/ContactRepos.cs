using DreemDay_Core.Context;
using DreemDay_Core.DTOs.ContactDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
  public class ContactRepos : IContactRepos
  {
    private readonly DreemDayDbContext _dbContext;

    public ContactRepos(DreemDayDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task CreateContact(Contact contact)
    {
      await _dbContext.Contacts.AddAsync(contact);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteContact(int id)
    {
      var contact = await _dbContext.Contacts.FindAsync(id);
      if (contact != null)
      {
        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task<List<Contact>> GelAllContact()
    {
      return await _dbContext.Contacts
          .Where(c => c.IsDeleted == false)
          .ToListAsync();
    }

    public async Task UpdateContactStatus(Contact contact)
    {
      _dbContext.Contacts.Update(contact);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<Contact> GetContactById(int id)
    {
      return await _dbContext.Contacts.FindAsync(id);
    }
  }
}
