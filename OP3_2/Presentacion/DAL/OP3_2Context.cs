namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Dominio.Models;

    public partial class OP3_2Context : DbContext
    {
        public System.Data.Entity.DbSet<Dominio.Models.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Dominio.Models.Barrio> Barrios { get; set; }
        public System.Data.Entity.DbSet<Dominio.Models.Vivienda> Viviendas { get; set; }
        public System.Data.Entity.DbSet<Dominio.Models.Parametro> Parametros { get; set; }
        

        public OP3_2Context() : base("name=OP3_2Context")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<OP3_2Context>(null);
            //base.OnModelCreating(modelBuilder);
        }

        
    }
}
