using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact Create(Contact contact)
        {
            return _contactRepository.Create(contact);
        }

        public StatusCodeResult Delete(long id)
        {
            var deletedContact = _contactRepository.Read(id);
            if (deletedContact == null)
                throw new Exception("Contact not found!");
            return _contactRepository.Delete(id);
        }

        public List<Contact> Read()
        {
            return _contactRepository.Read();
        }

        public Contact Read(long id)
        {
            return _contactRepository.Read(id);
        }

        public Contact Update(long id, Contact contact)
        {
            var savedContact = _contactRepository.Read(id);
            if (savedContact == null)
                throw new Exception("Contact not found!");

            return _contactRepository.Update(contact);
        }
    }
}
