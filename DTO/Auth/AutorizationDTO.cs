using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutorizationDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
