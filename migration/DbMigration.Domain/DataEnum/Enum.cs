using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DbMigration.Domain.DataEnum
{
    public class Enum
    {

        public enum PropertyStatus
        {
            [Description("None")]
            None = 0,

            [Description("Publish")]
            Publish = 2,

            [Description("Unpublish")]
            Unpublish = 3,

        }
        public enum Roles
        {
            SuperAdmin,
            Admin
        }
    }
}