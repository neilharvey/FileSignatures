Web Application Example
===========================

This example demonstrates how to examine the format of a file which has been uploaded to an ASP.NET Core web application.

Usage
-----

Run the web application and upload a file to the index page.  Image files will be accepted, and non-image files will be rejected irrespective of the extension or content-type headers provided by the browser.

Explanation
-----------

A concrete ```FileFormatInspector``` which recognises image formats is registered in the Startup class:

```cs
var recognised = FileFormatLocator.GetFormats().OfType<Image>();
var inspector = new FileFormatInspector(recognised);
services.AddSingleton<IFileFormatInspector>(inspector);
```

This can then be injected into the constructor of the HomeController:

```cs
public HomeController(IFileFormatInspector fileFormatInspector)
{
    this.fileFormatInspector = fileFormatInspector;
}
```
Then we can use this after a file has been posted back to verify that the uploaded file is an image:

```cs
[HttpPost]
public IActionResult Index(IFormFile file)
{
    FileFormat format;

    using(var stream = file.OpenReadStream())
    {
        format = fileFormatInspector.DetermineFileFormat(stream);
    }

    var model = new UploadResultModel()
    {
        Accepted = format is Image,
        MediaType = format?.MediaType,
        FileName = Path.GetFileName(file.FileName)
    };

    return RedirectToAction(nameof(Index), model);
}
```

This gives us a more reliable way of checking the content of an uploaded file than examining ```IFormFile.FileName``` or ```IFormFile.ContentType``` which are both under the control of the client.