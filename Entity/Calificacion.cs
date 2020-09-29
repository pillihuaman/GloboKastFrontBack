using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
   public class Calificacion
    {

        [Key]
        public int   IdCalificacion   {set;get;}
       public int   Idcliente        {set;get;}
       public int Punto            {set;get;}
       public DateTime   Fechacreacion    {set;get;}
        Cliente cliente { set; get; }

    }
}
