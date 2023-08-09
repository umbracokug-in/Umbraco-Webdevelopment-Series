using Umbraco.Cms.Web.Common.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.AspNetCore.Mvc;
using DemoUmbraco.Core.Services;
using DemoUmbraco.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoUmbraco.Models.CustomModels;
using Lucene.Net.Search.Similarities;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Polly;
using Umbraco.Cms.Web.Common;

namespace DemoUmbraco.Core.Controller
{
    public class InnerPageController : RenderController
    {
        #region declarations
        private readonly IPageContentService _iPageContentService;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        private readonly UmbracoHelper _umbracoHelper;
        #endregion declarations

        public InnerPageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor,
           IPageContentService iPageContentService, IVariationContextAccessor variationContextAccessor, ServiceContext context, UmbracoHelper umbracoHelper)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _iPageContentService = iPageContentService;
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = context;
            _umbracoHelper = umbracoHelper;
        }
        public override IActionResult Index()
        {
            return CurrentTemplate(CurrentPage);
        }
        public IActionResult? InnerPageTemplate()
        {
            //Document alias = controller name & Template alias = action name
            if (CurrentPage != null)
            {
                var pageModel = _iPageContentService.GetInnerPageContents(CurrentPage, _umbracoHelper, _serviceContext, _variationContextAccessor);
                return View(pageModel);
            }
            return null;
        }
    }
}
