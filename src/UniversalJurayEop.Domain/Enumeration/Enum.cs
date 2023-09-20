using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversalJurayEop.Domain.Enumeration
{
    public class Enum
    {
        public enum Roles
        {
            SuperAdmin,
            Admin,
            Basic

        }
        public enum PropertyStatus
        {
            [Description("None")]
            None = 0,

            [Description("Publish")]
            Publish = 2,

            [Description("Unpublish")]
            Unpublish = 3,

        }
        
    }
}