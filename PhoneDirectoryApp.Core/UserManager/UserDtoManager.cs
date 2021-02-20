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
   public  class UserDtoManager : IUserDtoManager
    {
        UnitOfWork uof = new UnitOfWork(new DatabaseContext());
        public User ConvertToUser(UserOfContactInfoDto userOfContactInfoDto)
        {
            User user = new User();
            user.ID = userOfContactInfoDto.ID;
            user.Name = userOfContactInfoDto.Name;
            user.Surname = userOfContactInfoDto.Surname;
            user.CompanyName = userOfContactInfoDto.CompanyName;
            return user;
        }

        public User AddPerson(UserOfContactInfoDto userOfContactInfoDto)
        {
            User user = ConvertToUser(userOfContactInfoDto);
            uof.userRepository.AddPerson(user);
            uof.Complete();

            return user;
        }
        public void DeletePerson(Guid ID)
        {
            User user = uof.userRepository.GetPerson(ID);
            uof.userRepository.DeletePerson(user);
            uof.Complete();
        }
        public UserOfContactInfoDto GetPerson(Guid id)
        {
            User user = uof.userRepository.GetPerson(id);
            ContactInfo contactInfo = uof.contactInfoRepository.GetContactPerson(user.ID);
            UserOfContactInfoDto userOfContactInfoDto = new UserOfContactInfoDto();
            userOfContactInfoDto.ID = user.ID;
            userOfContactInfoDto.Name = user.Name;
            userOfContactInfoDto.Surname = user.Surname;
            userOfContactInfoDto.CompanyName = user.CompanyName;
            userOfContactInfoDto.PhoneNumber = contactInfo.PhoneNumber;
            userOfContactInfoDto.Email = contactInfo.Email;
            userOfContactInfoDto.Address = contactInfo.Address;

            return userOfContactInfoDto;
        }

        public List<UserDto> GetAllPerson()
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

            return userList;
        }

        public List<UserDto> GetAllPersonForSearch(Guid id)
        {
            List<User> users = uof.userRepository.GetAllPerson();
            List<UserDto> allUsers = new List<UserDto>();
            foreach (var item in users)
            {

                if (item.ID != id)
                {
                    allUsers.Add(TransformDTO(item));
                }

            }
            return allUsers;
        }
        public UserDto TransformDTO(User user)
        {
            UserDto tmpUserDto = new UserDto();
            tmpUserDto.ID = user.ID;
            tmpUserDto.Name = user.Name;
            tmpUserDto.Surname = user.Surname;
            tmpUserDto.CompanyName = user.CompanyName;

            return tmpUserDto;
        }
    }
}
