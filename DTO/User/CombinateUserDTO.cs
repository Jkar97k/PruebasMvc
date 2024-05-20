using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CombinateUserDTO
    {
        public UsuarioDTO usuario { get; set; } = new UsuarioDTO();
        public UsuarioCreateDTO create { get; set; } = new UsuarioCreateDTO();
    }
}
