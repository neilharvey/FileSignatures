using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FileSignatures
{
    public static class FileFormatLocator
    {
        /// <summary>
        /// Returns all the default file formats.
        /// </summary>
        public static IEnumerable<FileFormat> GetFormats()
        {
            return GetFormats(typeof(FileFormatLocator).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Returns all the concrete <see cref="FileFormat"/> types found in the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly which contains the file format definitions.</param>
        public static IEnumerable<FileFormat> GetFormats(Assembly assembly)
        {
            if(assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            return assembly.GetTypes()
                 .Where(t => typeof(FileFormat).IsAssignableFrom(t))
                 .Where(t => !t.GetTypeInfo().IsAbstract)
                 .Where(t => t.GetConstructors().Any(c => c.GetParameters().Length == 0))
                 .Select(t => Activator.CreateInstance(t))
                 .OfType<FileFormat>();
        }

        /// <summary>
        /// Returns all the concrete <see cref="FileFormat"/> types found in the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly which contains the file format definitions.</param>
        /// <param name="includeDefaults">Whether to include the default format definitions with the results from the external assembly.</param>
        public static IEnumerable<FileFormat> GetFormats(Assembly assembly, bool includeDefaults)
        {
            var formatsInAssembly = GetFormats(assembly);

            if (!includeDefaults)
            {
                return formatsInAssembly;
            }
            else
            {
                var formatsThisAssembly = GetFormats();
                return formatsInAssembly.Union(formatsThisAssembly);
            }
        }
    }
}
