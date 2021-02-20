using PhoneDirectoryApp.Core.UserDTO;
using PhoneDirectoryApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.Core.UserManager
{
    public interface IUserDtoManager
    {
        User AddPerson(UserOfContactInfoDto userOfContactInfoDto);
        void DeletePerson(Guid ID);
        UserOfContactInfoDto GetPerson(Guid id);
        List<UserDto> GetAllPerson();
        List<UserDto> GetAllPersonForSearch(Guid id);
    }
}
