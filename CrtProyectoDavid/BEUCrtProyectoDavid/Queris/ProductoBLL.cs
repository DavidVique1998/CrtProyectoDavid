using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    public class ProductoBLL
    {
        public static void Create(Producto a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Producto.Add(a);
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

        public static Producto Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Producto.Find(id);
        }

        public static void Update(Producto Producto)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Producto.Attach(Producto);
                        db.Entry(Producto).State = System.Data.Entity.EntityState.Modified;
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
                        Producto Producto = db.Producto.Find(id);
                        db.Entry(Producto).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Producto> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Producto.Include(p=>p.Categoria).Include(p=>p.Promocion).ToList();
        }

        public static List<Producto> GetProdutsByCategory(int cat_id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Producto.Where(x => x.cat_id.Equals(cat_id)).ToList();
        }

        public static List<Producto> GetProdutsByPromocion(int prm_id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.Producto.Where(x => x.prm_id.Equals(prm_id)).ToList();
        }

    }
}
