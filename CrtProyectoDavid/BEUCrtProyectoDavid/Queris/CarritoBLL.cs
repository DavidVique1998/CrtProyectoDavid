using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    class CarritoBLL
    {
        public static void Create(Carrito a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Carrito.Add(a);
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

        public static Carrito Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Carrito.Find(id);
        }

        public static void Update(Carrito Carrito)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Carrito.Attach(Carrito);
                        db.Entry(Carrito).State = System.Data.Entity.EntityState.Modified;
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
                        Carrito Carrito = db.Carrito.Find(id);
                        db.Entry(Carrito).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Carrito> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Carrito.ToList();
        }

        public static List<Carrito> List(int cln_id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Carrito.Where(x => x.cln_id.Equals(cln_id)).ToList();
        }
    }
}
