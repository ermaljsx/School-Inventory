//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sekretari_Demo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mesuesi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mesuesi()
        {
            this.Auditoris = new HashSet<Auditori>();
            this.Klasas = new HashSet<Klasa>();
        }
    
        public int id_mesuesi { get; set; }
        public string emer { get; set; }
        public string mbiemri { get; set; }
        public string Nr_Telefoni { get; set; }
        public string email { get; set; }
        public int id_lenda { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auditori> Auditoris { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klasa> Klasas { get; set; }
        public virtual Lenda Lenda { get; set; }
    }
}
