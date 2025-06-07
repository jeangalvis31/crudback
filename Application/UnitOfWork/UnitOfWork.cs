using Application.Repository;
using Domain.Interfaces;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ContactContext _context;
        public IContact _contact;
        public UnitOfWork(ContactContext context)
        {
            _context = context;
        }

        public IContact Contacts
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_context);
                }
                return _contact;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
