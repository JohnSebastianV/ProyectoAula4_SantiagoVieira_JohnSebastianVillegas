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
    
    public partial class IntegranteEquipo
    {
        public int ID { get; set; }
        public int IdeaDeNegocioID { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
    
        public virtual IdeaDeNegocio IdeaDeNegocio { get; set; }
    }
}