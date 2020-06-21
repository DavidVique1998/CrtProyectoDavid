using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    class UsuarioBLL
    {
        
        public static void Create(Usuario a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuario.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                        Usuario u = GetUsuarioByUsu(a.uso_usu);
                        Cliente c = new Cliente();
                        c.uso_id = u.uso_id;
                        ClienteBLL.Create(c);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }


        }

        public static Usuario Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Usuario.Find(id);
        }

        public static void Update(Usuario usuario)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuario.Attach(usuario);
                        db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Usuario alumno = db.Usuario.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Usuario> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();

            return db.Usuario.ToList();
        }

        /*public static List<Usuario> ListToNames()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            List<Usuario> result = new List<Usuario>();
            db.Usuario.ToList().ForEach(x =>
                result.Add(
                    new 
                    {
                        nombres = x.nombres + " " + x.apellidos,
                        idalumno = x.idalumno
                    }));
            return result;
        }*/

        private static List<Usuario> GetUsuarios(string criterio)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Usuario.Where(x => x.uso_rol.ToLower().Contains(criterio)).ToList();
        }

        private static Usuario GetUsuario(string correo)
        {
            emmcomerseEntities  db = new emmcomerseEntities();
            return db.Usuario.FirstOrDefault(x => x.uso_cor == correo);
        }

        public static Usuario GetUsuarioByUsu(string usu)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Usuario.FirstOrDefault(x => x.uso_usu == usu);
        }

    }
}
