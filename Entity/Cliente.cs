using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Cliente
    {
        [Key]
        public int Idcliente { set; get; }
        public string Nombre { set; get; }
        public int IdUsuario { set; get; }
        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}
