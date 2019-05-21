using SQLInjectionUtils.CHARS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInjectionUtils
{
    /// <summary>
    /// TODO: Crear el zip de los datos u otro métdos
    /// </summary>
    public static class ConvertStrings
    {
        public static string ToDatabase(string msg) {
            
            EncodeBase64 simpleQuote = new EncodeBase64();
            return simpleQuote.Encode(msg);
        }

        public static string ToView(string msg) {
            EncodeBase64 simpleQuote = new EncodeBase64();
            return simpleQuote.Decode(msg);
        }
    }
}
