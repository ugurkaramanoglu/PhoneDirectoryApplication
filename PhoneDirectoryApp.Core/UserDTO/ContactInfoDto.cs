using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.Core.UserDTO
{
    public class ContactInfoDto
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid UserID { get; set; }
    }
}
