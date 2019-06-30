using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Models;
using DAL;
using System.Data.Entity;

namespace Dominio.Repositorios
{
    public class RepositorioUsuario
    {

        private OP3_2Context db = new OP3_2Context();

        //ADD
        public bool Add(Usuario usu)
        {
            db.Usuarios.Add(usu);
            db.SaveChanges();

            return true;
        }

        //ADD
        public bool AddPostulante(Postulante usu)
        {
            bool retorno = false;
            var existe = db.Postulantes.Count(u => u.Cedula == usu.Cedula);
            if (existe == 0)
            {
                usu.Rol = usu.getRol();
                usu.Salt = usu.generarSalPass();
                usu.Pass = Usuario.EncriptarPass(usu.Pass, usu.Salt, Usuario.getPimienta());
                db.Postulantes.Add(usu);
                db.SaveChanges();
                retorno = true;
            }
            return retorno;
        }

        //DELETE
        public bool Delete(Usuario usu)
        {
            db.Usuarios.Remove(usu);
            db.SaveChanges();

            return true;
        }

        //FINDALL
        public IEnumerable<Usuario> FindAll()
        {
            List<Usuario> listaUsuarios = db.Usuarios.ToList();

            return listaUsuarios;
        }

        public IEnumerable<Postulante> FindAllPostulantes()
        {
            List<Postulante> listaUsuarios = db.Postulantes.ToList();

            return listaUsuarios;
        }

        //BUSCA POR CEDULA
        public Usuario FindByCedula(string cedula)
        {
            Usuario usu = db.Usuarios.Where(u => u.Cedula == cedula).FirstOrDefault();
            return usu;
        }

        //BUSCA POR ID
        public Usuario FindById(int? id)
        {
            Usuario usu = db.Usuarios.Where(c => c.id == id).FirstOrDefault();
            return usu;
        }

        //BUSCA POR ID
        public Postulante FindByIdPostulante(int? id)
        {
            Postulante usu = db.Postulantes.Where(c => c.id == id).FirstOrDefault();
            return usu;
        }

        //BUSCA POR EMAIL
        public Usuario FindByEmail(string Email)
        {
            Usuario usu = db.Usuarios.Where(c => c.Email == Email).FirstOrDefault();
            return usu;
        }

        //ACTUALIZA
        public bool Update(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        //AGREGAR LISTA USUARIOS POSTULANTES
        public void AgregarListaUsuarios(List<Postulante> listaUsuarios) {            
            foreach (Postulante usu in listaUsuarios) {
                var existe = db.Postulantes.Count(u => u.Nombre == usu.Nombre);
                if (existe == 0) {
                    //usu.Rol = usu.getRol();
                    usu.Salt = usu.generarSalPass();
                    usu.Pass = Usuario.EncriptarPass(usu.Pass, usu.Salt, Usuario.getPimienta());
                    db.Postulantes.Add(usu);
                    db.SaveChanges();
                }
            }
        }

        //AGREGAR LISTA USUARIOS JEFE
        public void AgregarListaUsuariosJefe(List<Jefe> listaUsuarios)
        {
            foreach (Jefe usu in listaUsuarios)
            {
                var existe = db.Jefes.Count(u => u.Nombre == usu.Nombre);
                if (existe == 0)
                {
                    //usu.Rol = usu.getRol();
                    usu.Salt = usu.generarSalPass();
                    usu.Pass = Usuario.EncriptarPass(usu.Pass, usu.Salt, Usuario.getPimienta());
                    db.Jefes.Add(usu);
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