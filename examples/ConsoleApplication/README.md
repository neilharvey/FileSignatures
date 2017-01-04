Console Application Example
===========================

This example demonstrates how to examine the format of a file on the local machine via a console.

Usage
-----

From a command prompt within the ConsoleApplication directory, run the command:

```
dotnet run /path/to/file
```

This will examine the file and return the media type and description if recognised.  For example, if the file was identified as a JPEG then the following would be returned:

```
Media Type : image/jpeg
Signature  : FF-D8-FF-E0
Extension  : jpg
```