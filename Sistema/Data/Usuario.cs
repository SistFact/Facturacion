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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.inv_movencabezado = new HashSet<inv_movencabezado>();
        }
    
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> Administrador { get; set; }
    
        public virtual ICollection<inv_movencabezado> inv_movencabezado { get; set; }
    }
}
