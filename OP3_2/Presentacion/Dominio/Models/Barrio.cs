﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    [Table("Barrios")]
    public class Barrio
    {
        [Key]
        public int Id { get; set; } //identificador del Barrio

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Descripcion { get; set; }

    }
}