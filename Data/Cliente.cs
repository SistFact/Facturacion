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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Factura = new HashSet<Factura>();
        }
    
        public int CodCliente { get; set; }
        public string NombreCliente { get; set; }
        public string RNC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelMovil { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public Nullable<bool> EstadoCli { get; set; }
        public Nullable<int> TipoPrecio { get; set; }
    
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
