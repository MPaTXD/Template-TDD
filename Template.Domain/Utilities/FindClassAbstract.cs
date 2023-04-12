using Domain.Seedwork;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Utilities
{
    public static class FindClassAbstract
    {
        static FindClassAbstract() { }

        public static T CreateAbstract<T>(int id)
        {

            Type instance = Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                    .FirstOrDefault(x => ((Entity)Activator.CreateInstance(x)).Id  == id);


            if (instance == null)
            {
                return default(T);
            }

            return (T)Activator.CreateInstance(instance);
        }
    }
}
