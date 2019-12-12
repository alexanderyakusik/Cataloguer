using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cataloguer.Infrastructure.Classes
{
    public static class Reflection
    {
        public static IEnumerable<Type> GetTypesInheritedFrom<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(T).IsAssignableFrom(type) && type != typeof(T));
        }

        public static void ForceLoadAssemblies()
        {
            List<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            string[] loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            string[] referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            List<string> toLoad = referencedPaths
                .Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            toLoad.ForEach(path => loadedAssemblies.Add(
                AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))
            ));
        }
    }
}
