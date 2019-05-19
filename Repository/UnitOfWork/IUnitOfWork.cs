using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository User { get; }
        void Save();
    }
}
