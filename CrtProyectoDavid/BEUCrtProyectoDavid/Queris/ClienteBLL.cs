using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    class ClienteBLL
    {
        public static void Create(Cliente a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        a.cln_tipo = "Nuevo";
                        db.Cliente.Add(a);
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

        public static Cliente Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Cliente.Find(id);
        }

        public static void Update(Cliente Cliente)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Cliente.Attach(Cliente);
                        db.Entry(Cliente).State = System.Data.Entity.EntityState.Modified;
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
                        Cliente Cliente = db.Cliente.Find(id);
                        db.Entry(Cliente).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Cliente> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Cliente.ToList();
        }

        /*public static List<Cliente> ListToNames()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            List<Cliente> result = new List<Cliente>();
            db.Cliente.ToList().ForEach(x =>
                result.Add(
                    new Cliente
                    {
                        nombre = x.nrc + "-" + x.nombre,
                        idCliente = x.idCliente
                    }));
            return result;
        }*/
    }
}
