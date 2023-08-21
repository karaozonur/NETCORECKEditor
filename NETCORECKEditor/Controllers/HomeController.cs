using Microsoft.AspNetCore.Mvc;
using NETCORECKEditor.Models;
using System;
using System.Diagnostics;

namespace NETCORECKEditor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadCKEDITOR(IFormFile upload)
        {
            if (upload!=null && upload.Length>0)
            {
                var filename=DateTime.Now.ToString("yyyyMMddHHmmss")+upload.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), _hostingEnvironment.WebRootPath, "uploaded", filename);
                var str = new FileStream(path, FileMode.Create);
                upload.CopyToAsync(str);
                var url = $"{"/uploaded/"}{filename}";
                return Json(new { uploaded = true, url });
            }
            return Json(new { path = "/uploaded/" });
        }
        [HttpGet]
        public async Task<IActionResult> FileBrowserCKEDITOR(IFormFile upload)
        {
            var dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _hostingEnvironment.WebRootPath, "uploaded"));
            ViewBag.fileInfos=dir.GetFiles();
            return View("FileBrowserCKEDITOR");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}