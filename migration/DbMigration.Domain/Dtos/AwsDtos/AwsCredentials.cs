﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigration.Domain.Dtos.AwsDtos
{
    public class AwsCredentials
    {
        public string AccessKey { get; set; } = "";
        public string SecretKey { get; set; } = "";
    }
}
