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
    
    public partial class comprobanteTipo
    {
        public comprobanteTipo()
        {
            this.inv_movencabezado = new HashSet<inv_movencabezado>();
        }
    
        public string idNCF { get; set; }
        public string Descripcion { get; set; }
        public string prefijo { get; set; }
        public Nullable<int> secuencia { get; set; }
        public Nullable<int> limite { get; set; }
        public Nullable<bool> factura { get; set; }
        public bool Cambio { get; set; }

        public virtual ICollection<inv_movencabezado> inv_movencabezado { get; set; }
    }
}
