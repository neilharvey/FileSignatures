using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FileSignatures.Formats;

#if NET5_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace FileSignatures
{
    public static class FileFormatLocator
    {
        /// <summary>
        /// Returns all the default file formats.
        /// </summary>
        public static IEnumerable<FileFormat> GetFormats()
        {
            return GetBuiltInFormats();
        }

        /// <summary>
        /// Returns all the concrete <see cref="FileFormat"/> types found in the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly which contains the file format definitions.</param>
#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("This method uses reflection to scan for FileFormat types. For AOT compatibility, consider using GetFormats() without parameters for built-in formats, or manually register your custom formats.")]
#endif
        public static IEnumerable<FileFormat> GetFormats(Assembly assembly)
        {
            if(assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            // Check if this is our own assembly containing the built-in formats
            if (assembly == typeof(FileFormatLocator).Assembly)
            {
                return GetBuiltInFormats();
            }

            // For external assemblies, use reflection (with appropriate attributes for trimming analysis)
            return GetFormatsUsingReflection(assembly);
        }

        /// <summary>
        /// Returns all the concrete <see cref="FileFormat"/> types found in the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly which contains the file format definitions.</param>
        /// <param name="includeDefaults">Whether to include the default format definitions with the results from the external assembly.</param>
#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("This method uses reflection to scan for FileFormat types. For AOT compatibility, consider using GetFormats() without parameters for built-in formats, or manually register your custom formats.")]
#endif
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

        /// <summary>
        /// Uses reflection to discover FileFormat types in an assembly.
        /// This method is marked with appropriate attributes for trimming analysis.
        /// </summary>
#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("This method uses reflection to scan for FileFormat types which may be trimmed.")]
#endif
        private static IEnumerable<FileFormat> GetFormatsUsingReflection(Assembly assembly)
        {
            return assembly.GetTypes()
                 .Where(t => typeof(FileFormat).IsAssignableFrom(t))
                 .Where(t => !t.GetTypeInfo().IsAbstract)
                 .Where(t => t.GetConstructors().Any(c => c.GetParameters().Length == 0))
                 .Select(t => Activator.CreateInstance(t))
                 .OfType<FileFormat>();
        }

        /// <summary>
        /// Returns all the built-in file formats without using reflection.
        /// This method is AOT-compatible and avoids trimming warnings.
        /// </summary>
        private static IEnumerable<FileFormat> GetBuiltInFormats()
        {
            // Static registry of all built-in file formats
            // This replaces reflection-based discovery for AOT compatibility
            // Only includes concrete (non-abstract) classes with parameterless constructors
            return
            [
                new AdobePdf(),
                new Aiff(),
                new Amr(),
                new Avi(),
                new Bmp(),
                new Cab(),
                new CompiledHtmlHelp(),
                new Dicom(),
                new Dwg(),
                new Excel(),
                new ExcelBinary(),
                new ExcelLegacy(),
                new ExcelWithMacros(),
                new Executable(),
                new Flac(),
                new Flash(),
                new Gif(),
                new Gzip(),
                new Icon(),
                new Jpeg(),
                new JpegExif(),
                new JpegJfif(),
                new M4A(),
                new M4V(),
                new MicrosoftAccess(),
                new MicrosoftAccess2007(),
                new Midi(),
                new Mkv(),
                new MP4(),
                new MP4V1(),
                new Mpeg3(),
                new Ogg(),
                new OpenDocumentPresentation(),
                new OpenDocumentSpreadsheet(),
                new OpenDocumentText(),
                new OutlookMessage(),
                new OutlookPersonalStorage(),
                new Pdf(),
                new Photoshop(),
                new Png(),
                new PowerPoint(),
                new PowerPointLegacy(),
                new PowerPointWithMacros(),
                new Quicktime(),
                new Rar4(),
                new Rar5(),
                new RichTextFormat(),
                new SevenZip(),
                new Spiff(),
                new Swf(),
                new Tar(),
                new ThreeGpp(),
                new Tiff(),
                new BigEndianTiff(),
                new Vcard(),
                new Visio(),
                new VisioLegacy(),
                new Webp(),
                new Wmf(),
                new Wmv(),
                new Word(),
                new WordLegacy(),
                new WordWithMacros(),
                new WordTemplate(),
                new Xps(),
                new Zip()
            ];
        }
    }
}
