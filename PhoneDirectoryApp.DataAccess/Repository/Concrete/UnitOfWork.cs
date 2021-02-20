using PhoneDirectoryApp.DataAccess.PhoneContext;
using PhoneDirectoryApp.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
            contactInfoRepository = new ContactInfoRepository(_context);
        }
        public IUserRepository userRepository { get; }
        public IContactInfoRepository contactInfoRepository { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
