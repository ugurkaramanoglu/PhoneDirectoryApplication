using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.DataAccess.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IContactInfoRepository contactInfoRepository { get; }
        void Complete();
    }
}
