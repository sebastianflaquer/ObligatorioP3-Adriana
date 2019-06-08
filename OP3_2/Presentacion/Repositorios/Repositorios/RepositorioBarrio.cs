﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Models;
using DAL;
using System.Data.Entity;

namespace Dominio.Repositorios
{
    public class RepositorioBarrio : InterfacesRepositorio.IRepositorioBarrios
    {

        private OP3_2Context db = new OP3_2Context();


        public bool Add(Barrio bar)
        {
            db.Barrios.Add(bar);
            db.SaveChanges();
            return true;
        }

        public bool Delete(Barrio bar)
        {
            db.Barrios.Remove(bar);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Barrio> FindAll()
        {
            List<Barrio> listaBarrios = db.Barrios.ToList();

            return listaBarrios;
        }

        public Barrio FindById(int? id)
        {
            Barrio bar = db.Barrios.Where(b => b.Id == id).FirstOrDefault();
            return bar;
        }

        public Barrio FindByName(string nombre)
        {
            Barrio bar = db.Barrios.Where(b => b.Nombre == nombre).FirstOrDefault();
            return bar;
        }

        public bool Update(Barrio barrio)
        {
            db.Entry(barrio).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public void AgregarListaBarrios(List<Barrio> listaBarrios) {

            foreach (Barrio bar in listaBarrios) {
                //valida que exista
                var existe = db.Barrios.Where(b => b.Nombre == bar.Nombre).FirstOrDefault();
                
                //valida que sea valido
                bool esValido = ValidarBarrio(bar);
                
                if (existe == null && esValido) {
                    db.Barrios.Add(bar);
                    db.SaveChanges();
                }
            }
        }

        public bool ValidarBarrio(Barrio bar)
        {
            bool esValido = false;
            //valida Nombre
            bool nombreValido = ValidarTextos(bar.Nombre, 3, 50);
            bool DescripcionValido = ValidarTextos(bar.Descripcion, 3, 50);

            if (nombreValido && DescripcionValido) {
                esValido = true;
            }
            
            return esValido;
        }

        //VALIDAR TEXTO
        public bool ValidarTextos(string texto, int min, int max) {

            bool esValido = false;

            if (texto.Length > min && texto.Length <= max) {
                esValido = true;
            }

            return esValido;

        }

        //DISPOSE
        public void Dispose()
        {
            db.Dispose();
        }

    }
}