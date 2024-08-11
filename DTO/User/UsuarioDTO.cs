using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string guid { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public int? profesionId { get; set; }
        public string correo { get; set; }
    }
}
