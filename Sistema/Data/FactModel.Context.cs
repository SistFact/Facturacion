﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FacturacionEntities : DbContext
    {
        public FacturacionEntities()
            : base("name=FacturacionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoriaProd> CategoriaProd { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<comprobanteTipo> comprobanteTipo { get; set; }
        public virtual DbSet<documento> documento { get; set; }
        public virtual DbSet<inv_movdetalle> inv_movdetalle { get; set; }
        public virtual DbSet<inv_movencabezado> inv_movencabezado { get; set; }
        public virtual DbSet<ViewProduct> ViewProduct { get; set; }
    
        public virtual int ModificacionCliente(Nullable<int> codCliente, string nombreCliente, string rNC, string direccion, string telefono, string telMovil, string email, string contacto, Nullable<bool> estadoCli, Nullable<int> tipoPrecio)
        {
            var codClienteParameter = codCliente.HasValue ?
                new ObjectParameter("CodCliente", codCliente) :
                new ObjectParameter("CodCliente", typeof(int));
    
            var nombreClienteParameter = nombreCliente != null ?
                new ObjectParameter("NombreCliente", nombreCliente) :
                new ObjectParameter("NombreCliente", typeof(string));
    
            var rNCParameter = rNC != null ?
                new ObjectParameter("RNC", rNC) :
                new ObjectParameter("RNC", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var telMovilParameter = telMovil != null ?
                new ObjectParameter("TelMovil", telMovil) :
                new ObjectParameter("TelMovil", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contactoParameter = contacto != null ?
                new ObjectParameter("Contacto", contacto) :
                new ObjectParameter("Contacto", typeof(string));
    
            var estadoCliParameter = estadoCli.HasValue ?
                new ObjectParameter("EstadoCli", estadoCli) :
                new ObjectParameter("EstadoCli", typeof(bool));
    
            var tipoPrecioParameter = tipoPrecio.HasValue ?
                new ObjectParameter("TipoPrecio", tipoPrecio) :
                new ObjectParameter("TipoPrecio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModificacionCliente", codClienteParameter, nombreClienteParameter, rNCParameter, direccionParameter, telefonoParameter, telMovilParameter, emailParameter, contactoParameter, estadoCliParameter, tipoPrecioParameter);
        }
    
        public virtual int ModificacionProd(string codigoProd, string nombreProd, Nullable<decimal> precio1, Nullable<decimal> precio2, Nullable<decimal> precio3, Nullable<bool> estadoProd, Nullable<int> existenciaProd, Nullable<int> codCategoria, string unidadProd, Nullable<int> cantidadMin, Nullable<decimal> impuesto, Nullable<decimal> costoProd, string nota)
        {
            var codigoProdParameter = codigoProd != null ?
                new ObjectParameter("CodigoProd", codigoProd) :
                new ObjectParameter("CodigoProd", typeof(string));
    
            var nombreProdParameter = nombreProd != null ?
                new ObjectParameter("NombreProd", nombreProd) :
                new ObjectParameter("NombreProd", typeof(string));
    
            var precio1Parameter = precio1.HasValue ?
                new ObjectParameter("Precio1", precio1) :
                new ObjectParameter("Precio1", typeof(decimal));
    
            var precio2Parameter = precio2.HasValue ?
                new ObjectParameter("Precio2", precio2) :
                new ObjectParameter("Precio2", typeof(decimal));
    
            var precio3Parameter = precio3.HasValue ?
                new ObjectParameter("Precio3", precio3) :
                new ObjectParameter("Precio3", typeof(decimal));
    
            var estadoProdParameter = estadoProd.HasValue ?
                new ObjectParameter("EstadoProd", estadoProd) :
                new ObjectParameter("EstadoProd", typeof(bool));
    
            var existenciaProdParameter = existenciaProd.HasValue ?
                new ObjectParameter("ExistenciaProd", existenciaProd) :
                new ObjectParameter("ExistenciaProd", typeof(int));
    
            var codCategoriaParameter = codCategoria.HasValue ?
                new ObjectParameter("CodCategoria", codCategoria) :
                new ObjectParameter("CodCategoria", typeof(int));
    
            var unidadProdParameter = unidadProd != null ?
                new ObjectParameter("UnidadProd", unidadProd) :
                new ObjectParameter("UnidadProd", typeof(string));
    
            var cantidadMinParameter = cantidadMin.HasValue ?
                new ObjectParameter("CantidadMin", cantidadMin) :
                new ObjectParameter("CantidadMin", typeof(int));
    
            var impuestoParameter = impuesto.HasValue ?
                new ObjectParameter("Impuesto", impuesto) :
                new ObjectParameter("Impuesto", typeof(decimal));
    
            var costoProdParameter = costoProd.HasValue ?
                new ObjectParameter("CostoProd", costoProd) :
                new ObjectParameter("CostoProd", typeof(decimal));
    
            var notaParameter = nota != null ?
                new ObjectParameter("Nota", nota) :
                new ObjectParameter("Nota", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModificacionProd", codigoProdParameter, nombreProdParameter, precio1Parameter, precio2Parameter, precio3Parameter, estadoProdParameter, existenciaProdParameter, codCategoriaParameter, unidadProdParameter, cantidadMinParameter, impuestoParameter, costoProdParameter, notaParameter);
        }
    
        public virtual int EliminacionCat(Nullable<int> codCategoria, Nullable<bool> estado)
        {
            var codCategoriaParameter = codCategoria.HasValue ?
                new ObjectParameter("CodCategoria", codCategoria) :
                new ObjectParameter("CodCategoria", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminacionCat", codCategoriaParameter, estadoParameter);
        }
    
        public virtual int ModificacionUsers(Nullable<int> codUsuario, string nombre, Nullable<bool> administrador)
        {
            var codUsuarioParameter = codUsuario.HasValue ?
                new ObjectParameter("CodUsuario", codUsuario) :
                new ObjectParameter("CodUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var administradorParameter = administrador.HasValue ?
                new ObjectParameter("Administrador", administrador) :
                new ObjectParameter("Administrador", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModificacionUsers", codUsuarioParameter, nombreParameter, administradorParameter);
        }
    
        public virtual int ModificacionCat(Nullable<int> codCategoria, string descripcion, Nullable<bool> estado)
        {
            var codCategoriaParameter = codCategoria.HasValue ?
                new ObjectParameter("CodCategoria", codCategoria) :
                new ObjectParameter("CodCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModificacionCat", codCategoriaParameter, descripcionParameter, estadoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsercionCat(string descripcion, Nullable<bool> estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsercionCat", descripcionParameter, estadoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsercionCliente(string nombreCliente, string rNC, string direccion, string telefono, string telMovil, string email, string contacto, Nullable<bool> estadoCli, Nullable<int> tipoPrecio)
        {
            var nombreClienteParameter = nombreCliente != null ?
                new ObjectParameter("NombreCliente", nombreCliente) :
                new ObjectParameter("NombreCliente", typeof(string));
    
            var rNCParameter = rNC != null ?
                new ObjectParameter("RNC", rNC) :
                new ObjectParameter("RNC", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var telMovilParameter = telMovil != null ?
                new ObjectParameter("TelMovil", telMovil) :
                new ObjectParameter("TelMovil", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contactoParameter = contacto != null ?
                new ObjectParameter("Contacto", contacto) :
                new ObjectParameter("Contacto", typeof(string));
    
            var estadoCliParameter = estadoCli.HasValue ?
                new ObjectParameter("EstadoCli", estadoCli) :
                new ObjectParameter("EstadoCli", typeof(bool));
    
            var tipoPrecioParameter = tipoPrecio.HasValue ?
                new ObjectParameter("TipoPrecio", tipoPrecio) :
                new ObjectParameter("TipoPrecio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsercionCliente", nombreClienteParameter, rNCParameter, direccionParameter, telefonoParameter, telMovilParameter, emailParameter, contactoParameter, estadoCliParameter, tipoPrecioParameter);
        }
    
        public virtual int InsercionFactura(Nullable<int> codCliente, Nullable<int> codUsuario, Nullable<System.DateTime> fecha, Nullable<decimal> subTotal, Nullable<decimal> impuesto, Nullable<decimal> descuento, Nullable<decimal> total, Nullable<bool> estado)
        {
            var codClienteParameter = codCliente.HasValue ?
                new ObjectParameter("CodCliente", codCliente) :
                new ObjectParameter("CodCliente", typeof(int));
    
            var codUsuarioParameter = codUsuario.HasValue ?
                new ObjectParameter("CodUsuario", codUsuario) :
                new ObjectParameter("CodUsuario", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var subTotalParameter = subTotal.HasValue ?
                new ObjectParameter("SubTotal", subTotal) :
                new ObjectParameter("SubTotal", typeof(decimal));
    
            var impuestoParameter = impuesto.HasValue ?
                new ObjectParameter("Impuesto", impuesto) :
                new ObjectParameter("Impuesto", typeof(decimal));
    
            var descuentoParameter = descuento.HasValue ?
                new ObjectParameter("Descuento", descuento) :
                new ObjectParameter("Descuento", typeof(decimal));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(decimal));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsercionFactura", codClienteParameter, codUsuarioParameter, fechaParameter, subTotalParameter, impuestoParameter, descuentoParameter, totalParameter, estadoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsercionProd(string codigoProd, string nombreProd, Nullable<decimal> precio1, Nullable<decimal> precio2, Nullable<decimal> precio3, Nullable<bool> estadoProd, Nullable<int> existenciaProd, Nullable<int> codCategoria, string unidadProd, Nullable<int> cantidadMin, Nullable<decimal> impuesto, Nullable<decimal> costoProd, string nota)
        {
            var codigoProdParameter = codigoProd != null ?
                new ObjectParameter("CodigoProd", codigoProd) :
                new ObjectParameter("CodigoProd", typeof(string));
    
            var nombreProdParameter = nombreProd != null ?
                new ObjectParameter("NombreProd", nombreProd) :
                new ObjectParameter("NombreProd", typeof(string));
    
            var precio1Parameter = precio1.HasValue ?
                new ObjectParameter("Precio1", precio1) :
                new ObjectParameter("Precio1", typeof(decimal));
    
            var precio2Parameter = precio2.HasValue ?
                new ObjectParameter("Precio2", precio2) :
                new ObjectParameter("Precio2", typeof(decimal));
    
            var precio3Parameter = precio3.HasValue ?
                new ObjectParameter("Precio3", precio3) :
                new ObjectParameter("Precio3", typeof(decimal));
    
            var estadoProdParameter = estadoProd.HasValue ?
                new ObjectParameter("EstadoProd", estadoProd) :
                new ObjectParameter("EstadoProd", typeof(bool));
    
            var existenciaProdParameter = existenciaProd.HasValue ?
                new ObjectParameter("ExistenciaProd", existenciaProd) :
                new ObjectParameter("ExistenciaProd", typeof(int));
    
            var codCategoriaParameter = codCategoria.HasValue ?
                new ObjectParameter("CodCategoria", codCategoria) :
                new ObjectParameter("CodCategoria", typeof(int));
    
            var unidadProdParameter = unidadProd != null ?
                new ObjectParameter("UnidadProd", unidadProd) :
                new ObjectParameter("UnidadProd", typeof(string));
    
            var cantidadMinParameter = cantidadMin.HasValue ?
                new ObjectParameter("CantidadMin", cantidadMin) :
                new ObjectParameter("CantidadMin", typeof(int));
    
            var impuestoParameter = impuesto.HasValue ?
                new ObjectParameter("Impuesto", impuesto) :
                new ObjectParameter("Impuesto", typeof(decimal));
    
            var costoProdParameter = costoProd.HasValue ?
                new ObjectParameter("CostoProd", costoProd) :
                new ObjectParameter("CostoProd", typeof(decimal));
    
            var notaParameter = nota != null ?
                new ObjectParameter("Nota", nota) :
                new ObjectParameter("Nota", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsercionProd", codigoProdParameter, nombreProdParameter, precio1Parameter, precio2Parameter, precio3Parameter, estadoProdParameter, existenciaProdParameter, codCategoriaParameter, unidadProdParameter, cantidadMinParameter, impuestoParameter, costoProdParameter, notaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsercionUsers(string nombre, Nullable<bool> administrador)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var administradorParameter = administrador.HasValue ?
                new ObjectParameter("Administrador", administrador) :
                new ObjectParameter("Administrador", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsercionUsers", nombreParameter, administradorParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SpNumeradorDocumento(string idDocumento)
        {
            var idDocumentoParameter = idDocumento != null ?
                new ObjectParameter("IdDocumento", idDocumento) :
                new ObjectParameter("IdDocumento", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SpNumeradorDocumento", idDocumentoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SpNumeradorTipoComprobante(string idNCF)
        {
            var idNCFParameter = idNCF != null ?
                new ObjectParameter("IdNCF", idNCF) :
                new ObjectParameter("IdNCF", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SpNumeradorTipoComprobante", idNCFParameter);
        }
    }
}
