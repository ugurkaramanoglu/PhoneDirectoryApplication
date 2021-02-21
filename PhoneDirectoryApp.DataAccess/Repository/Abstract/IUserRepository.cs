using PhoneDirectoryApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetPerson(Guid id);
        List<User> GetAllPerson();
        void AddPerson(User user);
        void DeletePerson(User user);
    }
}
