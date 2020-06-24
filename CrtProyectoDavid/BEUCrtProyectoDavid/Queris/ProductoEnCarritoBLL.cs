using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCrtProyectoDavid.Queris
{
    public class ProductoEnCarritoBLL
    {
        public static void Create(ProductoEnCarrito a)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        a.pcr_est = "Pendiente";
                        a.pcr_dateOfCreated = DateTime.Now;
                        db.ProductoEnCarrito.Add(a);
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

        public static ProductoEnCarrito Get(int? id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.ProductoEnCarrito.Find(id);
        }

        public static void Update(ProductoEnCarrito ProductoEnCarrito)
        {
            using (emmcomerseEntities db = new emmcomerseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ProductoEnCarrito.Attach(ProductoEnCarrito);
                        db.Entry(ProductoEnCarrito).State = System.Data.Entity.EntityState.Modified;
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
                        ProductoEnCarrito ProductoEnCarrito = db.ProductoEnCarrito.Find(id);
                        db.Entry(ProductoEnCarrito).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<ProductoEnCarrito> List()
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.ProductoEnCarrito.Include(p=> p.Carrito).Include(p=>p.Producto).ToList();
        }

        public static List<ProductoEnCarrito> List(int car_id)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.ProductoEnCarrito.Where(x => x.car_id.Equals(car_id)).ToList();
        }

        public static List<ProductoEnCarrito> GetProdutsInCarByState(string pcr_est)
        {
            emmcomerseEntities db = new emmcomerseEntities();
            return db.ProductoEnCarrito.Where(x => x.pcr_est.Equals(pcr_est)).ToList();
        }
    }
}
