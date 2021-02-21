using PhoneDirectoryApp.Core.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.Core.UserManager
{
    public interface IContactInfoDtoManager
    {
        void AddContactInfo(ContactInfoDto ContactInfoDto);
        void DeleteContactInfoById(int ID);
        void DeleteContactInfo(Guid ID);
        ContactInfoDto GetContactPerson(Guid id);
        List<ContactInfoDto> GetAllContactInfoByUser(Guid ID);
        List<ContactInfoDto> GetAllContactInfo();
        RecordDto GetRecordUserCount(string location);
    }
}
