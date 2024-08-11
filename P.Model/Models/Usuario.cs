using System;
using System.Collections.Generic;

namespace P.Model.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Correo { get; set; }
    }
}
