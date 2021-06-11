using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API
{
    public static class TimezoneHelper
    {
        public static DateTime Now()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "GMT Standard Time");
        }
    }
}
