//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public Producto()
        {
            this.inv_movdetalle = new HashSet<inv_movdetalle>();
        }
    
        public int Codigo { get; set; }
        public string CodigoProd { get; set; }
        public string NombreProd { get; set; }
        public decimal Precio1 { get; set; }
        public Nullable<decimal> Precio2 { get; set; }
        public Nullable<decimal> Precio3 { get; set; }
        public bool EstadoProd { get; set; }
        public Nullable<int> ExistenciaProd { get; set; }
        public int CodCategoria { get; set; }
        public string UnidadProd { get; set; }
        public int CantidadMin { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> CostoProd { get; set; }
        public string Nota { get; set; }
    
        public virtual CategoriaProd CategoriaProd { get; set; }
        public virtual ICollection<inv_movdetalle> inv_movdetalle { get; set; }
    }
}
