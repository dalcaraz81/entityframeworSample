using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.PropertiesUtils
{
    public class PropertiesHelper
    {
        public static Hashtable GetProperties(PropertyInfo[] properties) {
            Hashtable hashtable = new Hashtable();            
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name] = info;
            }
            return hashtable;
        }
    }
}
