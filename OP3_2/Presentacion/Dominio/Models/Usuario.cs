using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Dominio.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string Rol { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string FechaNac { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string Pass { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }

        //ENCRIPTAR PASS
        public static string EncriptarPass(string passwordIngreso, string salt, string pimienta)
        {
            string hashresult = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordIngreso + salt + pimienta, "SHA1");
            return hashresult;
        }

        //GENERA LA SAL
        public string generarSalPass()
        {
            //crea un obketo random y setea el numero del resultado.
            Random r = new Random();
            string retorno = r.Next().ToString();
            return retorno;
        }

        //PIMIENTA
        public static string getPimienta()
        {
            string pimienta = "p1m13n7a";
            return pimienta;
        }

        public string getRol()
        {
            string rol = "Postulante";
            return rol;
        }


    }
}