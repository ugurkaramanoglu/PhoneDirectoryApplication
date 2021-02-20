using PhoneDirectoryApp.DataAccess.PhoneContext;
using PhoneDirectoryApp.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;

        }
    }
}
