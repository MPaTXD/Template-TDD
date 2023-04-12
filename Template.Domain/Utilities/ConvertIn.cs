using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Utilities
{
    public static class ConvertIn
    {
        static ConvertIn() { }

        public static Dictionary<string, object> Dictionary(object request)
        {
            return request.GetType()
                  .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                  .ToDictionary(prop => prop.Name, prop => prop.GetValue(request, null));
        }

        public static Dictionary<string, object> DictionaryDynamic(IEnumerable<dynamic> request)
        {
            return request.Select(x => ((IDictionary<string, object>)x).ToDictionary(ks => ks.Key, vs => vs.Value)).First();
        }

        public static List<Dictionary<string, object>> DictionaryDynamicList(IEnumerable<dynamic> request)
        {
            return request.Select(x => ((IDictionary<string, object>)x).ToDictionary(ks => ks.Key, vs => vs.Value)).ToList();
        }
    }
}
