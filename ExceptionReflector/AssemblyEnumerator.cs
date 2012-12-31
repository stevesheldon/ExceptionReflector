using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ExceptionReflector
{
    [Serializable]
    class AssemblyEnumerator
    {
        private string filePath;
        private Assembly assembly;

        public AssemblyEnumerator(string filePath)
        {
            this.filePath = filePath;
            assembly = Assembly.LoadFrom(filePath);                                  
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
        }

        public IEnumerable<string> NameSpaces
        {
            get
            {
                try
                {
                    Type[] types = assembly.GetTypes();
                    return types.Select(t => t.Namespace).Distinct();
                }
                catch (ReflectionTypeLoadException e)
                {
                    foreach (var loaderException in e.LoaderExceptions)
                    {
                        Debug.Print(loaderException.ToString());
                    }

                    return Enumerable.Empty<string>();
                }
            }
        }

        public IEnumerable<Type> GetClasses(string nameSpace)
        {
            return assembly.GetTypes().Where(t => !t.IsInterface && String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public IEnumerable<MethodInfo> GetMethodds(Type classType)
        {
            return classType.GetMethods();
        }
    }
}
