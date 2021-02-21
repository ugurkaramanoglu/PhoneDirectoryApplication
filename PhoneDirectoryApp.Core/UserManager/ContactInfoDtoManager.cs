using PhoneDirectoryApp.Core.UserDTO;
using PhoneDirectoryApp.DataAccess.Model;
using PhoneDirectoryApp.DataAccess.PhoneContext;
using PhoneDirectoryApp.DataAccess.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectoryApp.Core.UserManager
{
    public class ContactInfoDtoManager : IContactInfoDtoManager
    {
        UnitOfWork uof = new UnitOfWork(new DatabaseContext());


        public void AddContactInfo(ContactInfoDto contactInfoDto)
        {
            ContactInfo contactInfo = ConvertToContact(contactInfoDto);
            uof.contactInfoRepository.AddContactInfo(contactInfo);
            uof.Complete();
        }

        public void DeleteContactInfoById(int ID)
        {
            ContactInfo contactInfo = uof.contactInfoRepository.GetContactInfoById(ID);
            uof.contactInfoRepository.DeleteContactInfo(contactInfo);
            uof.Complete();
        }
        public void DeleteContactInfo(Guid ID)
        {
            ContactInfo contactInfo = uof.contactInfoRepository.GetContactInfo(ID);
            uof.contactInfoRepository.DeleteContactInfo(contactInfo);
            uof.Complete();
        }

        public ContactInfoDto GetContactPerson(Guid id)
        {
            ContactInfo contactInfo = uof.contactInfoRepository.GetContactPerson(id);
            return ConvertToContactDto(contactInfo);
        }
        public List<ContactInfoDto> GetAllContactInfo()
        {

            List<UserDto> userList = uof.userRepository.GetAllPerson().Select(x => new UserDto
            {
                CompanyName = x.CompanyName,
                Name = x.Name,
                ID = x.ID,
                Surname = x.Surname

            }).ToList();

            var userIdlist = userList.Select(x => x.ID).ToList();

            var contactInfolist = uof.contactInfoRepository.GetAllContactInfo().Where(x => userIdlist.Contains(x.UserID)).Select(y => new ContactInfoDto
            {
                Address = y.Address,
                ID = y.ID,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                UserID = y.UserID

            }).ToList();


            foreach (var item in userList)
            {
                item.contactInfoList = contactInfolist.Where(x => x.UserID == item.ID).ToList();

            }


            return contactInfolist;
        }
        public ContactInfoDto ConvertToContactDto(ContactInfo contactInfo)
        {
            ContactInfoDto contactInfoDto = new ContactInfoDto();
            contactInfoDto.PhoneNumber = contactInfo.PhoneNumber;
            contactInfoDto.Email = contactInfo.Email;
            contactInfoDto.Address = contactInfo.Address;
            contactInfo.UserID = contactInfo.UserID;
            return contactInfoDto;
        }
        public ContactInfo ConvertToContact(ContactInfoDto contactInfoDto)
        {
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.PhoneNumber = contactInfoDto.PhoneNumber;
            contactInfo.Email = contactInfoDto.Email;
            contactInfo.Address = contactInfoDto.Address;
            contactInfo.UserID = contactInfoDto.UserID;
            return contactInfo;
        }

        public List<ContactInfoDto> GetAllContactInfoByUser(Guid ID)
        {
            var contactInfolist = uof.contactInfoRepository.GetAllContactInfoByUser(ID).Where(x => x.UserID == ID).Select(y => new ContactInfoDto
            {
                Address = y.Address,
                ID = y.ID,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                UserID = y.UserID

            }).ToList();

            return contactInfolist;

        }

        public RecordDto GetRecordUserCount(string location)
        {
            List<int> reportList = uof.contactInfoRepository.GetRecordUserCount(location);
            RecordDto recordDto = new RecordDto();


            recordDto.recordUsersCount = reportList[0];
            recordDto.recordNumberCount = reportList[1];
            recordDto.Location = location;

            return recordDto;
        }
    }
}
