using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Services
{
    public interface IContactService
    {
        Contact Create(Contact contact);
        List<Contact> Read();
        Contact Read(long id);
        Contact Update(long id, Contact contact);
        StatusCodeResult Delete(long id);
    }
}
