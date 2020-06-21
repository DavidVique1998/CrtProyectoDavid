using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    class PromocionBLL
    {
        public static void Create(Promocion a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Promocion.Add(a);
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

        public static Promocion Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Promocion.Find(id);
        }

        public static void Update(Promocion Promocion)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Promocion.Attach(Promocion);
                        db.Entry(Promocion).State = System.Data.Entity.EntityState.Modified;
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
                        Promocion alumno = db.Promocion.Find(id);
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

        public static List<Promocion> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();

            return db.Promocion.ToList();
        }
    }
}
