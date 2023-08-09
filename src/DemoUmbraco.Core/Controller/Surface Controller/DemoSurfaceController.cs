using DemoUmbraco.Models.Models.CustomModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

using DemoUmbraco.Models.CustomModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Drawing;


namespace DemoUmbraco.Core.Controller
{
    public class DemoSurfaceController : SurfaceController
    {
        public DemoSurfaceController(IUmbracoContextAccessor umbracoContextAccessor,
           IUmbracoDatabaseFactory databaseFactory,ServiceContext services,
           AppCaches appCaches,IProfilingLogger profilingLogger,
           IPublishedUrlProvider publishedUrlProvider)
           : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {

        }

        public IActionResult Index()
        {
            //umbraco/surface/demosurface/
            return Content("Hello World");
        }
        [Route("umbraco/customRoutedSurfaceController/PrintHelloMessage")]
        public string PrintMessage(string name = "Narnia")
        {
            //umbraco/customRoutedSurfaceController/PrintHelloMessage?name=Adrian
            return "Hello " + name;
        }
        
        public IActionResult HandleFormSubmission(FormModel formData)
        {            
            var name = formData.Name;
            var phone = formData.Phone;
            var email = formData.Email;
            var message = formData.Message;            
            var redirectPage = CurrentPage.Value<IPublishedContent>("redirectPage");
            if(redirectPage != null)
            {
                return RedirectToUmbracoPage(redirectPage);
            }            
            return RedirectToCurrentUmbracoPage();            
        }
    }
}
