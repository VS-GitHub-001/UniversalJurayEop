using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalJurayEop.Application.DTOs
{
    public class ChangeEvent
    {
        public DateTime Timestamp { get; set; }
        public string EntityName { get; set; }
        public string EntityState { get; set; }
    }
}
