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
    
    public partial class PlatoIngrediente
    {
        public int IdPlatoIngrediente { get; set; }
        public int Plato { get; set; }
        public int Cantidad { get; set; }
        public int Unidad_de_Medida { get; set; }
        public int Ingrediente { get; set; }
    
        public virtual Ingredientes Ingredientes { get; set; }
        public virtual Medidas Medidas { get; set; }
        public virtual Platos Platos { get; set; }
    }
}
