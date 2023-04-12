using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Utilities.Helper
{
    public static class FromToHelper
    {
        static FromToHelper() { }

        public static object MapDictToObj<T>(Dictionary<string, object> dict)
        {

            object returnobj = Activator.CreateInstance(typeof(T));

            foreach (string key in dict.Keys)
            {
                object value = dict[key];

                FieldInfo field = typeof(T).GetField(key);
                if (field != null)
                {
                    field.SetValue(returnobj, value);
                }


            }

            return returnobj;
        }

        public static string GetValueString(Dictionary<string, object> keyValuePairs, string key)
        {
            var keyValue = keyValuePairs.Where(x => x.Key.ToLowerInvariant() == key.ToLowerInvariant()).FirstOrDefault().Value;

            return keyValue == null ? null : keyValue.ToString();
        }

        public static int? GetValueInt(Dictionary<string, object> keyValuePairs, string key)
        {
            var keyValue = keyValuePairs.Where(x => x.Key.ToLowerInvariant() == key.ToLowerInvariant()).FirstOrDefault().Value;

            return keyValue != null ? Convert.ToInt32(keyValue.ToString()) : default(int?);
        }

        public static T GetValue<T>(Dictionary<string, object> keyValuePairs, string key)
        {
            var keyValue = keyValuePairs.Where(x => x.Key.ToLowerInvariant() == key.ToLowerInvariant()).FirstOrDefault().Value;

            return keyValue != null ? (T)keyValue : default(T);
        }
    }
}
