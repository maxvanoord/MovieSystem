using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Helpers
{
    public class TimeConverter
    {
        public static string ToMovieTime(int minutes)
        {
            int h = minutes / 60;
            if (h < 1)
                return $"{minutes}min";
            else
                return $"{h}h {minutes % 60}min";
        }
    }
}
