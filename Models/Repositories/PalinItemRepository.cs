using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome.Models.Repositories
{
    public class PalinItemRepository: IPalinItemRepository
    {
        private readonly AppDbContext _context;
        public PalinItemRepository(AppDbContext dbContext)
        {
            this._context = dbContext;
        }

        public void Add(string value, string hash)
        {
            PalinItem item = new PalinItem();
            item.Text = value;
            item.Hash = hash;
            _context.Add(item);
            _context.SaveChanges();
        }

        public PalinItem Get(string hash)
        {
            return _context.PalinItems.Where(item => String.Compare(item.Hash, hash, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }

        public PalinItem Get(int id)
        {
            return _context.PalinItems.Where(item => item.Id == id).FirstOrDefault();
        }

        public IEnumerable<PalinItem> GetAll()
        {
            return _context.PalinItems.ToList();
        }
    }
}