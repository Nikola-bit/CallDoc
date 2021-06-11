using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API
{
    public static class TimezoneExtensions
    {
        public static DateTime London(this DateTime dt)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "GMT Standard Time");
        }
    }
}
