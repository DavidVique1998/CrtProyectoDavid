//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUCrtProyectoDavid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.ProductoEnCarrito = new HashSet<ProductoEnCarrito>();
        }
        [ScaffoldColumn(false)]
        public int prd_id { get; set; }
        [ScaffoldColumn(false)]
        public int cat_id { get; set; }
        [ScaffoldColumn(false)]
        public int prm_id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El Nombre es requerido"), MaxLength(50)]
        [Display(Name = "Nombre")]
        public string prd_nom { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La Imagen es requerida"), MaxLength(100)]
        [Display(Name = "Imagen")]
        public string prd_img { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La talla es requerida"), MaxLength(5)]
        [Display(Name = "Talla")]
        public string prd_tal { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Las caracteristicas son requeridas"), MaxLength(150)]
        [Display(Name = "Caracteristicas")]
        public string prd_crt { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "La cantidad es requerida"),]
        [Display(Name = "Cantidad")]
        public Nullable<int> prd_cnt { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> prd_dateOfCreated { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Promocion Promocion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoEnCarrito> ProductoEnCarrito { get; set; }
    }
}
