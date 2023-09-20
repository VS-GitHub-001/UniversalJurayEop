 using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using UniversalJurayEop.Application.Interfaces;

namespace UniversalJurayEop.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
