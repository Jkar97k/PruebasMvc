using P.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Service
{
    public class RequestResponse : IRequestResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
