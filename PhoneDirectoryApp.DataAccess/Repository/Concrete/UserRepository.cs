using PhoneDirectoryApp.DataAccess.Model;
using PhoneDirectoryApp.DataAccess.PhoneContext;
using PhoneDirectoryApp.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        private DatabaseContext Context
        {
            get { return _context as DatabaseContext; }
        }

        public void AddPerson(User user)
        {
            _context.Users.Add(user);
        }

        public void DeletePerson(User user)
        {
            _context.Users.Remove(user);
        }

        public List<User> GetAllPerson()
        {

            return _context.Users.ToList();
        }

        public User GetPerson(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.ID == id);
        }
    }
}
