using System;
using System.Collections.Generic;

namespace P.Model.Models
{
    public partial class Profesion
    {
        public Profesion()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
