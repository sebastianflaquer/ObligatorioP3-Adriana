using DAL;
using Dominio.Models;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Repositorios.Repositorios
{
    public class RepositorioSorteo
    {

        private OP3_2Context db = new OP3_2Context();
        RepositorioVivienda repoViv = new RepositorioVivienda();
        RepositorioBarrio repoBar = new RepositorioBarrio();
        RepositorioUsuario repoUsu = new RepositorioUsuario();

        public bool Add(Sorteo sor)
        {
            db.Sorteos.Add(sor);
            db.SaveChanges();

            return true;
        }

        public bool Delete(Sorteo sor)
        {
            db.Sorteos.Remove(sor);
            db.SaveChanges();

            return true;
        }

        public IEnumerable<Sorteo> FindAll()
        {
            List<Sorteo> listaSorteos = db.Sorteos.ToList();

            return listaSorteos;
        }

        public Sorteo FindById(int? id)
        {
            Sorteo sor = db.Sorteos.Where(b => b.Id == id).FirstOrDefault();
            return sor;
        }

        public bool Update(Sorteo sorteo)
        {
            db.Entry(sorteo).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        //DISPOSE
        public void Dispose()
        {
            db.Dispose();
        }

        //CREAR SORTEO
        public void crearSorteo(Sorteo sorteo, int idVivienda)
        {
            //chekea que ya vivienda no este en otro sorteo.            
            bool encontro = false;
            List<Sorteo> listaSorteos = db.Sorteos.ToList();

            foreach (var sor in listaSorteos) {
                if (sor.Viv.Id == idVivienda) {
                    encontro = true;
                }
            }

            if (!encontro) {
                using (OP3_2Context otrodb = new OP3_2Context())
                {
                    sorteo.Viv = otrodb.Viviendas.Find(idVivienda); //repoViv.FindById(nombreVivienda);

                    otrodb.Entry(sorteo.Viv).State = EntityState.Unchanged;
                    otrodb.Entry(sorteo.Viv.Barrio).State = EntityState.Unchanged;

                    otrodb.Sorteos.Add(sorteo);
                    otrodb.SaveChanges();
                }
            }
        }

        //REALIZAR SORTEO
        public Sorteo relizarSorteo(int? idSorteo)
        {
            Sorteo sorteo = FindById(idSorteo);
            int cant = Convert.ToInt32(sorteo.listaUsuario.LongCount());
            if (cant > 0) {
                var randomNumber = new Random().Next(1, cant);

                IEnumerable<Usuario> listaOrd = sorteo.listaUsuario.ToList();
                listaOrd = listaOrd.OrderBy(s => s.Apellido);

                sorteo.UsuGanador = listaOrd.ElementAt(randomNumber-1);
                sorteo.Viv.Estado = "Sorteada";

                db.Entry(sorteo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return sorteo;
        }

        //INSCRIBIR USUARIO
        public void inscribirUsuario(int idSorteo, string cedulaUsuario)
        {
            using (var db = new OP3_2Context())
            {
                Usuario usuCedula = repoUsu.FindByCedula(cedulaUsuario);

                //Usuario usu = db.Usuarios.Find(usuCedula.id);
                Postulante usu = db.Postulantes.Find(usuCedula.id);
                Sorteo sor = db.Sorteos.Find(idSorteo);

                bool encontro = false;

                foreach (var item in sor.listaUsuario) {
                    if (item.Cedula == cedulaUsuario) {
                        encontro = true;
                    }
                }

                if (encontro == false) {
                    sor.listaUsuario.Add(usu);
                    db.Entry(sor).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            

            //Usuario usu = new Usuario();
            //usu = db.Usuarios.Find(usuCedula.id);
            //Sorteo sor = db.Sorteos.Find(idSorteo);
            //if (sor.UsuarioSorteo == null)
            //{
            //    ICollection<UsuarioSorteo> nuevaLista = new ICollection<UsuarioSorteo>();
            //    nuevaLista.Add(usu);
            //    sor.UsuarioSorteo = nuevaLista;
            //}
            //else {
            //    sor.UsuarioSorteo.Add(usu);
            //}           
            //sor.Usu = usu;
            //db.Entry(sor).State = EntityState.Modified;
            //db.SaveChanges();
            //this.Update(sor);

        }
    }
}