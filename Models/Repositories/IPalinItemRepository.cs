using System.Collections.Generic;

namespace Palindrome.Models.Repositories
{
    public interface IPalinItemRepository
    {
        void Add(string item, string hash);
        IEnumerable<PalinItem> GetAll();

        PalinItem Get(string hash);

        PalinItem Get(int id);
    }
}