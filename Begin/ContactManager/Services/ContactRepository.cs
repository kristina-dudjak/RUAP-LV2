using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using System.Runtime.Caching;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            if(MemoryCache.Default[CacheKey] == null)
            {
                var contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2, Name = "Dan Roth"
                }
            };
                MemoryCache.Default[CacheKey] = contacts;
            }
        }
        public Contact[] GetAllContacts()
        {
            if (MemoryCache.Default[CacheKey] != null)
            {
                return (Contact[])MemoryCache.Default[CacheKey];
            }

            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        public bool SaveContact(Contact contact)
        {
            try
            {
                var currentData = ((Contact[])MemoryCache.Default[CacheKey]).ToList();
                currentData.Add(contact);
                MemoryCache.Default[CacheKey] = currentData.ToArray();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
