using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Palindrome.Models;
using Palindrome.Services;

namespace Palindrome.Controllers
{
    [Route("api/palindrome")]
    public class PalindromeController : Controller
    {
        private readonly IPalinService _service;
        private readonly ILogger _logger;

        public PalindromeController(IPalinService palinService,
                ILogger<PalindromeController> logger)
        {
            _service = palinService;
            _logger = logger;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            _logger.LogDebug(1, "GetAll");
            RespMsg response = new RespMsg();
            response.status = true;
            response.data = _service.GetAll();
            return new OkObjectResult(response);
        }

        [HttpPost]
        [Route("check")]
        public IActionResult  Check([FromBody] CheckPalindromeRequest item) {
            _logger.LogDebug(1, "Check");
            if (item == null || String.IsNullOrEmpty(item.inputStr))
            {
                return BadRequest();
            }

            RespMsg response = new RespMsg();

            bool isPalindrome = _service.CheckPalindrome(item.inputStr);
            if( isPalindrome) {
                if(item.insert) {
                    _service.AddToDb(item.inputStr);
                    response.status = true;
                    response.data = _service.Get(item.inputStr);
                }
            } else {
                response.status = false;
                response.data = "Not a Palindrome";
            }

            return new OkObjectResult(response);
        }
        
        public class CheckPalindromeRequest
        {
            public string inputStr { get; set; }
            public bool insert { get; set; }
        }
    }
}
