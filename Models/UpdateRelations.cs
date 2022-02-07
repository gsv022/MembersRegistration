using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembersRegistration.Models
{
    public class UpdateRelations
    {
        public long Id { get; set; }
        public Nullable<long> UserId { get; set; }
        public long ApplicationId { get; set; }
        public long RelationId { get; set; }
        public long ApplicationName { get; set; }
    }
}