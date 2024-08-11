using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioCreateDTO
    {
        public string guid { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public string name { get; set; }
        public string correo { get; set; }
        public int? profesionId { get; set; }
    }
}
