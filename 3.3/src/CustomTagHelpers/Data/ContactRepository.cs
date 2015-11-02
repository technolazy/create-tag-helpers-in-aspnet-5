using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTagHelpers.Data
{
    public class ContactRepository
    {
        private readonly List<Contact> _contacts = new List<Contact>();
        public ContactRepository()
        {
            _contacts.Add(new Contact
            {
                Id = Guid.NewGuid(),
                Email = "johndoe@foo.com"
            });

            _contacts.Add(new Contact
            {
                Id = Guid.NewGuid(),
                Email = "jmcpeak@foo.com"
            });
        }

        public async Task<Contact> GetAsync(string username)
        {
            return _contacts.SingleOrDefault(c => c.Email.ToLower() == username.ToLower());
        }
    }

    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
