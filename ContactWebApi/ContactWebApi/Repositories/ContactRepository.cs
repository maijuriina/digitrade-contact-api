using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactappContext _context;
        
        public ContactRepository(ContactappContext context)
        {
            _context = context;
        }

        public Contact Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public StatusCodeResult Delete(long id)
        {
            var deletedContact = Read(id);
            _context.Remove(deletedContact);
            _context.SaveChanges();
            return new OkResult();
        }

        public List<Contact> Read()
        {
            return _context.Contact
                .AsNoTracking()
                .ToList();
        }

        public Contact Read(long id)
        {
            return _context.Contact.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public Contact Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}
