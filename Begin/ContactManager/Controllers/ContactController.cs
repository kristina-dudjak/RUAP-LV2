using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using ContactManager.Services;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        [HttpGet]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }

        [HttpPost]
        public IActionResult Post([FromForm]Contact contact)
        {
            this.contactRepository.SaveContact(contact);
            return CreatedAtAction(nameof(Get),contact);
        }
    }
}
