using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    public static class Extentions
    {
        public static bool IsNumber(this string s)
        {
            if (s.Length == 0)
                return false;

            for (int i = 0; i < s.Length; i++)
                if (s[i] < '0' || s[i] > '9')
                    return false;

            return true;
        }

    }
}
