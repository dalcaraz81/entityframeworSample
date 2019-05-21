using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInjectionUtils.CHARS
{
    public class EncodeBase64
    {

        public string Encode(string msg) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);
            return  System.Convert.ToBase64String(bytes) ;
        }

        public string Decode(string msg) {
            byte[] bytes = System.Convert.FromBase64String(msg);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        

    }
}
