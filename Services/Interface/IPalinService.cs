using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Palindrome.Models;

namespace Palindrome.Services
{
    public interface IPalinService
    {
        bool CheckPalindrome(string str);

        void AddToDb(string str);

        IEnumerable<PalinItem> GetAll();

        PalinItem Get(int id);

        PalinItem Get(string str);
    }
}