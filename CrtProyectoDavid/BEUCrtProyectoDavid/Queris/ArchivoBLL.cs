using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BEUCrtProyectoDavid.Queris
{
    public class ArchivoBLL
    {
        public string confirmacion { get; set; }
        public Exception error { get; set; }
        
        public void SubirArchivo(string ruta,HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.confirmacion = "Imagen Guardada";
            }
            catch (Exception ex)
            {
                this.error = ex;
                throw;
            }
        }




     }
}
