using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Palindrome.Models;
using Palindrome.Models.Repositories;

namespace Palindrome.Services
{
    public class PalinService : IPalinService
    {
        private readonly IPalinItemRepository _repo;
        public PalinService(IPalinItemRepository palinItemRepo){
            _repo = palinItemRepo;

        }
        public void AddToDb(string str)
        {
            string hash = calulateHash(str);
            PalinItem item = _repo.Get(hash);

            if( item == null) {
                _repo.Add(str, hash);
            }
        }

        public string calulateHash(string val)
        {
            string input = val.ToLower();
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public bool CheckPalindrome(string str)
        {
            Regex rgx = new Regex(@"/[^A-Z0-9]/ig");
            string removeChar = rgx.Replace(str, "").ToLower();
            return removeChar.SequenceEqual(removeChar.Reverse());
        }

        public PalinItem Get(int id)
        {
            return _repo.Get(id);
        }

        public PalinItem Get(string str)
        {
            return _repo.Get(calulateHash(str));
        }

        public IEnumerable<PalinItem> GetAll()
        {
            return _repo.GetAll();
        }
    }
}