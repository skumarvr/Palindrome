using System.ComponentModel.DataAnnotations;

namespace Palindrome.Models
{
    public class RespMsg
    {
        public bool status = false;
        public string errMsg = "";
        public object data;
    }
}