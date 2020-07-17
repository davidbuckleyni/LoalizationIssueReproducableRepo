using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoalizationIssueReproducableRepo.Models;
using Microsoft.Extensions.Localization;
using SharedResourceLib.Lng;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace LoalizationIssueReproducableRepo.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<  SharedResource> _sharedLocalizer;
        
        public HomeController(ILogger<HomeController> logger , IStringLocalizer<SharedResource> sharedLocalizer) {
            _logger = logger;
            _sharedLocalizer = sharedLocalizer;

        }

        public IActionResult Index() {

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = rqf.RequestCulture.Culture;
            var isNotound = _sharedLocalizer["Hello"].ResourceNotFound;
            var resourceval = _sharedLocalizer["Hello"];

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl) {


            Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
        new CookieOptions {
            Expires = DateTimeOffset.UtcNow.AddYears(1),
            IsEssential = true,  //critical settings to apply new culture
            Path = "/",
            HttpOnly = false,
        }
    );


            return LocalRedirect(returnUrl);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
