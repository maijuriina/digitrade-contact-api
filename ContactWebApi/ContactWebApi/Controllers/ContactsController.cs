using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactWebApi.Services;
using ContactWebApi.Repositories;
using ContactWebApi.Models;

namespace ContactWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;

        public ContactsController(IContactRepository contactRepository, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        // CRUD R / GET api/contacts
        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return new JsonResult(_contactService.Read());
        }

        // GET api/contact/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(long id)
        {
            var contact = _contactService.Read(id);
            return new JsonResult(contact);
        }

        // CRUD C / POST api/Contact
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            var newContact = _contactService.Create(contact);
            return new JsonResult(newContact);
        }

        // CRUD U / PUT api/Contacts/5
        [HttpPut("{id}")]
        public ActionResult<Contact> Put(long id, Contact contact)
        {
            var updateContact = _contactService.Update(id, contact);
            return new JsonResult(updateContact);
        }

        // CRUD D / DELETE api/contacts/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _contactService.Delete(id);
            return new NoContentResult();
        }
    }
}