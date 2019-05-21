using SQLInjectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Strings
{
    public class SanitaizeStrings
    {
        public static string ToDb(string msg) {
            return ConvertStrings.ToDatabase(msg);
        }

        public static string ToView(string msg) {
            return ConvertStrings.ToView(msg);
        }
    }
}
