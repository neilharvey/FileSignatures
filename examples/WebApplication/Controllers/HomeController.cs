using FileSignatures;
using FileSignatures.Formats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileFormatInspector fileFormatInspector;

        public HomeController(IFileFormatInspector fileFormatInspector)
        {
            this.fileFormatInspector = fileFormatInspector;
        }

        [HttpGet]
        public IActionResult Index(UploadResultModel model)
        {
            return View(model);
        }

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

        public IActionResult Error()
        {
            return View();
        }
    }
}
