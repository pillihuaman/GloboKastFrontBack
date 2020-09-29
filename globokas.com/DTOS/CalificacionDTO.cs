using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
   public class CalificacionDTO
    {

        [Key]
        public int   IdCalificacion   {set;get;}
       public int   Idcliente        {set;get;}
       public int Punto            {set;get;}
       public DateTime   Fechacreacion    {set;get;}
        ClienteDTO cliente { set; get; }

    }
}
