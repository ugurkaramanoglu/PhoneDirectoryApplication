using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.Core.UserDTO
{
    public class UserDto
    {
        public UserDto()
        {
            contactInfoList = new List<ContactInfoDto>();
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ContactInfoDto> contactInfoList { get; set; }
    }
}
