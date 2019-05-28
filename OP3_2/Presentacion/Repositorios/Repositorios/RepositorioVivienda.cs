using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Models;
using DAL;
using System.Data.Entity;

namespace Dominio.Repositorios
{
    public class RepositorioVivienda
    {

        private OP3_2Context db = new OP3_2Context();


        public bool Add(Vivienda vivienda)
        {
            db.Viviendas.Add(vivienda);
            db.SaveChanges();

            return true;
        }

        public bool Delete(Vivienda vivienda)
        {
            db.Viviendas.Remove(vivienda);
            db.SaveChanges();

            return true;
        }

        public IEnumerable<Vivienda> FindAll()
        {
            List<Vivienda> listaViviendas = db.Viviendas.ToList();

            return listaViviendas;
        }

        public Vivienda FindById(int? id)
        {
            Vivienda viv = db.Viviendas.Where(v => v.Id == id).FirstOrDefault();
            return viv;
        }

        public bool Update(Vivienda vivienda)
        {
            db.Entry(vivienda).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public void AgregarListaVivienda(List<Vivienda> listaVivienda) {
            
            foreach (Vivienda viv in listaVivienda) {

                var existe = db.Viviendas.Where(v => v.Id == viv.Id).FirstOrDefault();

                if (existe == null) {
                    db.Viviendas.Add(viv);
                    db.SaveChanges();
                }

            }
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}