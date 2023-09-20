using DbMigration.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigration.Domain.Models
{
    public class Food : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }

    }
}
