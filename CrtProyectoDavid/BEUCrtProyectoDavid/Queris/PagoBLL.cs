using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    public class PagoBLL
    {
        public static void Create(Pago a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        db.Pago.Add(a);
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

        public static Pago Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Pago.Find(id);
        }

        public static void Update(Pago Pago)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Pago.Attach(Pago);
                        db.Entry(Pago).State = System.Data.Entity.EntityState.Modified;
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
                        Pago Pago = db.Pago.Find(id);
                        db.Entry(Pago).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Pago> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Pago.Include(p => p.Cliente).ToList();
        }

        public static List<Pago> List(int cln_id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Pago.Where(x => x.cln_id.Equals(cln_id)).ToList();
        }

    }
}
