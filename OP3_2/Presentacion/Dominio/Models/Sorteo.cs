﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    [Table("Sorteos")]
    public class Sorteo
    {

        [Key]
        public int Id { get; set; } //identificador del Sorteo

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set;}
        
        public virtual Vivienda Viv { get; set; }
        //public virtual Usuario Usu { get; set; }

        public virtual ICollection<Usuario> listaUsuarios { get; set; }
    }
}