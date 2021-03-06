//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestauranteAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Platos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platos()
        {
            this.PlatoEtiqueta = new HashSet<PlatoEtiqueta>();
            this.PlatoIngrediente = new HashSet<PlatoIngrediente>();
        }
    
        public int IdPlato { get; set; }
        public string Plato { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public string Imagen { get; set; }
    
        public virtual Categoria Categoria1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatoEtiqueta> PlatoEtiqueta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatoIngrediente> PlatoIngrediente { get; set; }
    }
}
