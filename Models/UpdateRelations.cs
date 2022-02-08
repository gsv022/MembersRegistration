using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembersRegistration.Models
{
    public class UpdateRelations
    {
        public Nullable<long> UserId { get; set; }
        public long ApplicationId { get; set; }
        public long RelationId { get; set; }
        public string ApplicationName { get; set; }
    }
}