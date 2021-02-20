using PhoneDirectoryApp.DataAccess.Model;
using PhoneDirectoryApp.DataAccess.PhoneContext;
using PhoneDirectoryApp.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Concrete
{
    public class ContactInfoRepository : Repository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        private DatabaseContext Context
        {
            get { return _context as DatabaseContext; }
        }

        public void AddContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);

        }

        public void DeleteContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Remove(contactInfo);
        }

        public List<ContactInfo> GetAllContactInfoByUser(Guid ID)
        {
            return _context.ContactInfos.ToList();
        }
        public List<ContactInfo> GetAllContactInfo()
        {
            return _context.ContactInfos.ToList();
        }

        public ContactInfo GetContactPerson(Guid id)
        {
            return _context.ContactInfos.FirstOrDefault(x => x.UserID == id);
        }

        public ContactInfo GetContactInfoById(int id)
        {
            return _context.ContactInfos.FirstOrDefault(x => x.ID == id);
        }
        public ContactInfo GetContactInfo(Guid id)
        {
            return _context.ContactInfos.FirstOrDefault(x => x.UserID == id);
        }

        public List<int> GetRecordUserCount(string location)
        {

            List<int> reportList = new List<int>();
            reportList.Add(_context.ContactInfos.Where(x => x.Address == location).Select(x => x.UserID).ToList().Distinct().Count());

            reportList.Add(_context.ContactInfos.Where(x => x.Address == location).Select(x => x.PhoneNumber).ToList().Count());

            return reportList;
        }
    }
}
