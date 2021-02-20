using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Model
{
    public class User
    {
        public User()
        {
            contactInfo = new List<ContactInfo>();
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> contactInfo { get; set; }
    }
}
