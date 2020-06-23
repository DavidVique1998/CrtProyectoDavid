using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    public class CuerpoFacturaBLL
    {
        public static void Create(CuerpoFactura a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CuerpoFactura.Add(a);
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

        public static CuerpoFactura Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.CuerpoFactura.Find(id);
        }

        public static void Update(CuerpoFactura CuerpoFactura)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CuerpoFactura.Attach(CuerpoFactura);
                        db.Entry(CuerpoFactura).State = System.Data.Entity.EntityState.Modified;
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
                        CuerpoFactura CuerpoFactura = db.CuerpoFactura.Find(id);
                        db.Entry(CuerpoFactura).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<CuerpoFactura> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.CuerpoFactura.Include(c=>c.CabezaFactura).Include(c=>c.Carrito).ToList();
        }

    }
}
