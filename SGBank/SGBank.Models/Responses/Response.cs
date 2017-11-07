using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Responses
{
    public class Response   // Specific response types will inherit from this
    {
        public bool Success { get; set; }       //refered to as flag
        public string Message { get; set; }     //messages meant for user
    }
}
