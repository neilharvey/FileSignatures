# FileSignatures

[![build status](https://ci.appveyor.com/api/projects/status/github/neilharvey/filesignatures?svg=true)](https://ci.appveyor.com/project/neilharvey/filesignatures)
[![nuget package](https://badge.fury.io/nu/FileSignatures.svg)](https://www.nuget.org/packages/FileSignatures)

A small library for detecting the type of a file based on header signature (also known as magic number) rather than file extension.  It is designed with extensibility in mind, so that recognised formats can be added easily.

## How do I install it?

FileSignatures is available on NuGet, so can be installed via the Package Manager:

```
Install-Package FileSignatures
```

## How do I use it?

Create an instance of the FileFormatInspector class, then pass it a stream to your file:

```cs
var inspector = new FileFormatInspector();
var format = inspector.DetermineFileFormat(stream);
``` 

This will return a FileFormat instance which contains the signature and media type of the recognised format,
or null if a matching format could not be determined.

## How do I register it with a dependency injection container?

You can either register an instance calling the empty constructor which will register all formats in the FileSignatures assembly:

```cs
services.AddSingleton<IFileFormatInspector>(new FileFormatInspector());
```

Or use `FileFormatLocator` to scan for the formats you are interested in then pass that to the constructor of `FileFormatInspector` and register that instance:

```cs
var recognised = FileFormatLocator.GetFormats().OfType<Image>();
var inspector = new FileFormatInspector(recognised);
services.AddSingleton<IFileFormatInspector>(inspector);
```
    
In this example, only formats which derive from `Image` (jpg, tiff, bmp, etc.) will be detected.  Anything else will be ignored.

## How do I check for a type of file?

Because the formats are defined as a type hierarchy, you can either check for a specific type if you want
to work with a particular format, or the base type if you are interested in multiple formats.

```cs
var format = inspector.DetermineFileFormat(stream);

if(format is Pdf) {
  // Just matches Pdf
}

if(format is OfficeOpenXml) {
  // Matches Word, Excel, Powerpoint
}

if(format is Image) {
  // Matches any image format
}

```

See the examples for a sample [web application](https://github.com/neilharvey/FileSignatures/tree/master/examples/WebApplication) and a [console application](https://github.com/neilharvey/FileSignatures/tree/master/examples/ConsoleApplication) which demonstrate how to filter uploads by a particular format and retrieve the signature details for a file.

## What formats are recognised?

Currently, the following formats are built-in:

| Name                       | Media-Type                                                                | Extension
|----------------------------|---------------------------------------------------------------------------|--------
| Bitmap                     | image/bitmap                                                              | .bmp
| Excel                      | application/vnd.openxmlformats-officedocument.spreadsheetml.sheet         | .xlsx
| Excel 97-2003              | application/vnd.ms-excel                                                  | .xls
| Windows Executable         | application/octet-stream                                                  | .exe
| GIF                        | image/gif                                                                 | .gif
| JPEG                       | image/jpeg                                                                | .jpeg
| Open Document Presentation | application/vnd.oasis.opendocument.presentationn                          | .odp
| Open Document Spreadhseet  | application/vnd.oasis.opendocument.spreadsheet                            | .ods
| Open Document Text         | application/vnd.oasis.opendocument.text                                   | .odt
| Outlook Message            | application/vnd.ms-outlook                                                | .msg
| PDF                        | application/pdf                                                           | .pdf
| PNG                        | image/png                                                                 | .png
| PowerPoint                 | application/vnd.openxmlformats-officedocument.presentationml.presentation | .pptx
| Powerpoint 97-2003         | application/vnd.ms-powerpoint                                             | .ppt
| Rich Text Format           | application/rtf                                                           | .rtf
| TIFF                       | image/tiff                                                                | .tif
| Visio                      | application/vnd.visio                                                     | .vsdx
| Visio 97-2003              | application/vnd.visio                                                     | .vsd
| Word                       | application/vnd.openxmlformats-officedocument.wordprocessingml.document   | .docx
| Word 97-2003               | application/msword                                                        | .doc
| Xps                        | application/vnd.ms-xpsdocument                                            | .xps
| Zip                        | application/zip                                                           | .zip

## How do I add additional formats?

Create a new class (or many classes) which inherit from `FileFormat` to implement a custom format. Next, pass a collection of recognised formats to the constructor of `FileFormatInspector`, being sure to include your custom format.

The `FileFormatLocator` class can be used to load all custom formats located within an assembly:

```cs 
var assembly = typeof(CustomFileFormat).GetTypeInfo().Assembly;

// Just the formats defined in the assembly containing CustomFileFormat
var customFormats = FileFormatLocator.GetFormats(assembly);

// Formats defined in the assembly and all the defaults
var allFormats = FileFormatLocator.GetFormats(assembly, true);
```

Using this method, you can continue to create custom formats and they will automatically be included into the recognised formats without any additional configuration.

## What is the licence?

This project is licensed under the [MIT license](LICENSE).
