using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContact
    {
        private readonly ContactContext _context;
        public ContactRepository(ContactContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public override async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
