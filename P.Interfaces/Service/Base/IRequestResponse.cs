using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Interfaces
{
    public interface IRequestResponse
    {
        string Message { get; set; }
        int StatusCode { get; set; }
    }
}
