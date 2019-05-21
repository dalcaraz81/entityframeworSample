using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utils.Strings;

namespace Utils
{
    public static class AutoMapper
    {
        public static List<T> MapModelCollection<T>(this IDataReader dr) where T : new()
        {
            Type business = typeof(T);
            List<T> entities = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = business.GetProperties();
            foreach (PropertyInfo info in properties) {
                hashtable[info.Name.ToUpper()] = info;
            }
            while (dr.Read()) {
                T item = new T();
                for (int i = 0; i < dr.FieldCount; i++) {
                    PropertyInfo info = (PropertyInfo)hashtable[dr.GetName(i).ToUpper()];
                    if (info != null && info.CanWrite) {
                        Type infoField = info.PropertyType;
                        if (infoField.FullName.ToLower() == "system.string")
                        {
                            info.SetValue(item, SanitaizeStrings.ToView((string)dr.GetValue(i)), null);
                        }
                        else {
                            info.SetValue(item, dr.GetValue(i), null);
                        }
                        
                    }
                }
                entities.Add(item);
            }
            return entities;
        }
    }
}
