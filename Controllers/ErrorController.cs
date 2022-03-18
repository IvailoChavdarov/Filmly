using Filmly.Models;
using Filmly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ServerError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/statuscode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            StatusCodeErrorViewModel error = new StatusCodeErrorViewModel();
            error.ErrorCode = statusCode.ToString();
            switch (statusCode)
            {
                case 404:
                    error.ErrorDescription = "Sorry, the resource you requested could not be found.";
                    break;
                case 403:
                    error.ErrorDescription = "Page is forbidden!";
                    break;
                case 405:
                    error.ErrorDescription = "Not allowed.";
                    break;
                case 500:
                    error.ErrorDescription = "Internal Server Error";
                    break;
                case 505:
                    error.ErrorDescription = "HTTP Version Not Suppported";
                    break;
            }

            return View("StatusCodeError", error);
        }
    }
}
