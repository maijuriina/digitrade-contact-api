﻿using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(int id)
        {
            var deleteContact = Read(id);
            _context.Remove(deleteContact);
            _context.SaveChanges();
            return;
        }

        public List<Contact> Read()
        {
            return _context.Contact
                .AsNoTracking()
                .ToList();
        }

        public Contact Read(int id)
        {
            return _context.Contact.FirstOrDefault(c => c.Id == id);
        }

        public Contact Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}
