using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class RolDTO
    {
        [Key]
        public int Idrol { set; get; }
        public string Descripcion { set; get; }
        public bool Estado { set; get; }
    }

}