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
    
    public partial class Member
    {
        public long Id { get; set; }
        public long RelationId { get; set; }
        public string members { get; set; }
    
        public virtual Relationship Relationship { get; set; }
    }
}
