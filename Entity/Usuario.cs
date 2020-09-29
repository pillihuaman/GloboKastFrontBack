using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { set; get; }
        public string Correo { set; get; }
        public string Password { set; get; }
        public int IdRol { set; get; }
        public string Descripcion { set; get; }
        public bool Estado           {set;get;}
       public DateTime FechaCreacion { set; get; }
        public Rol rol { set; get; }
    }
}
