//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Factura = new HashSet<Factura>();
        }
    
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> Administrador { get; set; }
    
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
