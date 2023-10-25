//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAula4_SantiagoVieira_JohnSebastianVillegas
{
    using System;
    using System.Collections.Generic;
    
    public partial class IdeaDeNegocio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdeaDeNegocio()
        {
            this.IntegranteEquipo = new HashSet<IntegranteEquipo>();
            this.Departamento = new HashSet<Departamento>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ImpactoSocialEconomico { get; set; }
        public decimal ValorInversion { get; set; }
        public decimal ValorInversionInfraestructura { get; set; }
        public decimal Ingresos3Anios { get; set; }
        public int Herramienta4RIID { get; set; }
    
        public virtual Herramienta4RI Herramienta4RI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegranteEquipo> IntegranteEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departamento> Departamento { get; set; }
    }
}