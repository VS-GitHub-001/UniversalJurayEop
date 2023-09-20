using DbMigration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigration.Infrastructure.Services
{
    public class MainServices
    {

        public static string SelectColor()
        {
            string xcolor = "";
            var list = new List<string> { "bg-red", "bg-yellow", "bg-aqua", "bg-blue",
                    "bg-green", "bg-navy", "bg-teal", "bg-olive", "bg-lime", "bg-orange", "bg-fuchsia", "bg-purple",
                    "bg-maroon", "bg-gray" }; var random = new Random();
            xcolor = list[random.Next(list.Count)];
            return xcolor;
        }
    }
}
