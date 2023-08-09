using DemoUmbraco.Models.CustomModels;
using DemoUmbraco.Models.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;

namespace DemoUmbraco.Core.Services.Interfaces
{
    public interface IPageContentService
    {
        public ProductAPIModel GetProductsDetails(int nodeId, UmbracoHelper _umbracoHelper);
        public MemberAPIModel GetMemberDetails(int nodeId, UmbracoHelper _umbracoHelper);
        public NodeDetailsAPIModel GetNodeDetails(int nodeId, UmbracoHelper _umbracoHelper);

        public InnerPageModel GetInnerPageContents(IPublishedContent CurrentPage, UmbracoHelper _umbracoHelper, ServiceContext _serviceContext, IVariationContextAccessor _variationContextAccessor);
    }
}
