using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NHibernate;
using PetStore.Core.Infrastructure.InversionOfControl;
using PetStore.Core.Infrastructure.UnitOfWork;

namespace PetStore.Infrastructure.NHibernate.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly Dictionary<int, ITransaction> Transactions = new Dictionary<int, ITransaction>();
        private readonly object _sync = new object();
        private readonly bool _isChild;
        private bool _commited = false;

        public UnitOfWork()
        {
            lock (_sync)
            {
                if (Transactions.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                {
                    _isChild = true;
                }
                else
                {
                    Transactions.Add(Thread.CurrentThread.ManagedThreadId, IoC.Resolve<IDatabaseSessionFactory>().Retrieve().BeginTransaction());
                    _isChild = false;
                }
            }
        }

        public void Commit()
        {
            if (!_isChild)
            {
                lock (_sync)
                {
                    Transactions[Thread.CurrentThread.ManagedThreadId].Commit();
                    _commited = true;
                }
            }
        }

        public void Dispose()
        {
            if (!_isChild)
            {
                lock (_sync)
                {
                    if (!_commited)
                    {
                        Transactions[Thread.CurrentThread.ManagedThreadId].Rollback();
                    }
                    Transactions[Thread.CurrentThread.ManagedThreadId].Dispose();
                    Transactions.Remove(Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }
}
