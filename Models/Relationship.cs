//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MembersRegistration.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relationship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Relationship()
        {
            this.Members = new HashSet<Member>();
        }
    
        public long RelationId { get; set; }
        public long UserId { get; set; }
        public long ApplicationId { get; set; }
        public string Relation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
        public virtual ProfileCreation ProfileCreation { get; set; }
        public virtual UserRegistration UserRegistration { get; set; }
    }
}
