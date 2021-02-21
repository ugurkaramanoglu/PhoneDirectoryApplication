using PhoneDirectoryApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Abstract
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {
        void AddContactInfo(ContactInfo contactInfo);
        void DeleteContactInfo(ContactInfo contactInfo);
        public ContactInfo GetContactPerson(Guid UserId);
        List<ContactInfo> GetAllContactInfoByUser(Guid ID);
        List<ContactInfo> GetAllContactInfo();
        ContactInfo GetContactInfoById(int id);
        ContactInfo GetContactInfo(Guid id);

        List<int> GetRecordUserCount(string location);
    }
}
