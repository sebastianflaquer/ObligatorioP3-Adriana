using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    public class UsuarioSorteo
    {
        // full join table
        [Table("UsuarioSorteo")]
        public class ActorMovieModel
        {
            [Key, Column(Order = 1, TypeName = "int")]
            [ForeignKey("Usuario")]
            public int idUsuario { get; set; }
            public Usuario Usuario { get; set; }

            [Key, Column(Order = 2, TypeName = "int")]
            [ForeignKey("Sorteo")]
            public int idSorteo { get; set; }
            public Sorteo Movie { get; set; }
        }



    }
}