using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectoryApp.Core.UserDTO;
using PhoneDirectoryApp.Core.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        IUserDtoManager _userDtoManager;
        IContactInfoDtoManager _contactInfoDtoManager;
        public UserController(IUserDtoManager userDtoManager, IContactInfoDtoManager contactInfoDtoManager)
        {
            _userDtoManager = userDtoManager;
            _contactInfoDtoManager = contactInfoDtoManager;
        }

        [HttpPost]
        public void CreatePerson(UserOfContactInfoDto userOfContactInfoDto)
        {
            ContactInfoDto contactInfoDto = new ContactInfoDto();
            Guid guid = Guid.NewGuid();
            userOfContactInfoDto.ID = guid;
            _userDtoManager.AddPerson(userOfContactInfoDto);
            contactInfoDto.Address = userOfContactInfoDto.Address;
            contactInfoDto.Email = userOfContactInfoDto.Email;
            contactInfoDto.PhoneNumber = userOfContactInfoDto.PhoneNumber;
            contactInfoDto.UserID = userOfContactInfoDto.ID;
            _contactInfoDtoManager.AddContactInfo(contactInfoDto);
        }
        [HttpPost]
        public void CreateContactInfo(ContactInfoDto contactInfoDto)
        {

            _contactInfoDtoManager.AddContactInfo(contactInfoDto);
        }
        [HttpGet]
        public UserOfContactInfoDto GetPerson(UserOfContactInfoDto userOfContactInfoDto)
        {
            Guid ID = userOfContactInfoDto.ID;
            UserOfContactInfoDto userOfContactInfoDtoGet = _userDtoManager.GetPerson(ID);
            return userOfContactInfoDtoGet;
        }
        public ContactInfoDto GetContactPerson(UserOfContactInfoDto userOfContactInfoDto)
        {
            Guid ID = userOfContactInfoDto.ID;
            ContactInfoDto contactInfoDto = _contactInfoDtoManager.GetContactPerson(ID);
            return contactInfoDto;
        }

        public List<UserDto> GetAllPerson()
        {
            List<UserDto> userDtosList = _userDtoManager.GetAllPerson();
            return userDtosList;
        }
        [HttpPost]
        public List<ContactInfoDto> GetAllContactInfo(UserOfContactInfoDto userOfContactInfoDto)
        {
            Guid ID = userOfContactInfoDto.ID;
            List<ContactInfoDto> contactDtosList = _contactInfoDtoManager.GetAllContactInfoByUser(ID);
            return contactDtosList;
        }


        public void DeletePerson(UserOfContactInfoDto userOfContactInfoDto)
        {
            Guid ID = userOfContactInfoDto.ID;
            if (userOfContactInfoDto.PhoneNumber == null)
            {
                _userDtoManager.DeletePerson(ID);
            }
            else
            {
                _contactInfoDtoManager.DeleteContactInfo(ID);
                _userDtoManager.DeletePerson(ID);
            }

        }
        [HttpPost]
        public void DeleteContactInfo(ContactInfoDto contactInfoDto)
        {
            _contactInfoDtoManager.DeleteContactInfoById(contactInfoDto.ID);
        }

        public List<UserDto> SearchPartial(string text)
        {
            Guid Id = Guid.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).SingleOrDefault());

            List<UserDto> users = _userDtoManager.GetAllPersonForSearch(Id);
            List<UserDto> searchresults = new List<UserDto>();
            if (!string.IsNullOrEmpty(text))
            {
                foreach (var item in users)
                {
                    if (item.Name.ToLower().Contains(text.ToLower()))
                    {
                        searchresults.Add(item);
                    }
                }
            }
            return searchresults;
        }

        [HttpPost]
        public RecordDto PostRecordCounts(ContactInfoDto contactInfoDto)
        {
            RecordDto recordDto = new RecordDto();
            recordDto = _contactInfoDtoManager.GetRecordUserCount(contactInfoDto.Address);
            return recordDto;
        }



    }
}
