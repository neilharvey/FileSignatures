# FileSignatures

[![build status ](https://ci.appveyor.com/api/projects/status/github/neilharvey/filesignatures?svg=true)](https://ci.appveyor.com/project/neilharvey/filesignatures)

A small library for determining the file type of a binary stream using file header signatures.

## How do I install it?

FileSignatures is available on NuGet, so can be installed via the Package Manager:

```
Install-Package FileSignatures -pre
```

## How do I use it?

Create an instance of the FileFormatInspector class, then pass it a stream to your file:

```cs
var inspector = new FileFormatInspector();
var format = inspector.DetermineFileFormat(stream);
``` 

This will return a FileFormat instance which contains the signature and media type of the recognised format,
or null if a matching format could not be determined.

## How do I check for a type of file?

Because the formats are defined as a type hierarchy, you can either check for a specific type if you want
to work with a particular format, or the base type if you are interested in multiple formats.

```cs
var format = inspector.DetermineFileFormat(stream);

if(format is Pdf) {
  // Do something with Reader 
}

if(format is OfficeOpenXml) {
  // Do something with Office
}

```

## How do I add additional formats?

Create a new class which inherits from FileFormat, then add this to the default formats and
pass the entire collection to the FileFormatInspector.

```cs
var formats = FileFormatLocator.GetFormats();
var custom = new CustomFileFormat();
formats.Add(custom);
var inspector = new FileFormatInspector(formats);
```

However, this way does not lend itself well to maintenance if new custom types are added on an ongoing basis so the FileLocator class can be used to load all custom formats located in an assembly:

```cs 
var assembly = typeof(CustomFileFormat).GetTypeInfo().Assembly;

// Just the formats defined in the assembly containing CustomFileFormat
var customFormats = FileLocator.GetFormats(assembly);

// Formats defined in the assembly and all the defaults
var allFormats = FileLocator.GetFormats(assembly, true);
```

## What is the licence?

This project is licensed under the [MIT license](LICENSE.TXT).
