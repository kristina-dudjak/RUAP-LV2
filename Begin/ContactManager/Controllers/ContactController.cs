using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public Contact[] Get()
        {
            return new Contact[]
            {
                new Contact
                {
                    Id = 1,
                    Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2,
                    Name = "Dan Roth"
                }
            };
        }
    }
}
