using DemoUmbraco.Core.Services.Interfaces;
using DemoUmbraco.Models.CustomModels;
using DemoUmbraco.Models.Models.CustomModels;
using Lucene.Net.Search.Similarities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;

namespace DemoUmbraco.Core.Services
{
    public class PageContentService : IPageContentService
    {
        private readonly IUserService _userService;
        public PageContentService(IUserService userService)
        {
            _userService = userService;
        }

        public ProductAPIModel GetProductsDetails(int nodeId, UmbracoHelper _umbracoHelper)
        {
            var productNode = _umbracoHelper.Content(nodeId);
            var productTitle = productNode?.Value<string>("title");
            var productDescription = productNode?.Value<string>("description");
            var productCapacity = productNode?.Value<string>("capacity");
            var productPrice = productNode?.Value<string>("price");
            var productColour = productNode?.Value<string>("colour");

            ProductAPIModel productAPIModel = new ProductAPIModel
            {
                Title=productTitle,
                Description= productDescription,
                Capacity = productCapacity,
                Price = productPrice,
                Colour = productColour
            };
            return productAPIModel;
        }
        public MemberAPIModel GetMemberDetails(int nodeId, UmbracoHelper _umbracoHelper)
        {
            var memberNode = _umbracoHelper.Content(nodeId);
            var memberName = memberNode?.Value<string>("memberName");
            var designation = memberNode?.Value<string>("designation");
            var phoneNumber = memberNode?.Value<string>("phoneNumber");
            var emailId = memberNode?.Value<string>("emailId");
            var region = memberNode?.Value<string>("region");

            MemberAPIModel memberAPIModel = new MemberAPIModel
            {
                Name = memberName,
                Designation = designation,
                PhoneNumber = phoneNumber,
                EmailId = emailId,
                Region = region
            };
            return memberAPIModel;

        }
        public NodeDetailsAPIModel? GetNodeDetails(int nodeId, UmbracoHelper _umbracoHelper)
        {
            var details = string.Empty;
            var umbracoNode = _umbracoHelper.Content(nodeId);
            if (umbracoNode != null)
            {
                var nodeName = umbracoNode.Name;
                var nodeCreatedDate = umbracoNode.CreateDate;
                int nodeCreatedById = umbracoNode.CreatorId;

                // Get the User by ID
                IUser user = _userService.GetUserById(nodeCreatedById);

                NodeDetailsAPIModel nodeDetailsAPIModel = new NodeDetailsAPIModel
                {
                    Name = nodeName,
                    CreatedBy = user?.Name,
                    ContentType = umbracoNode.ContentType?.Alias,
                    CreatedOn = nodeCreatedDate.ToString()
                };
                return nodeDetailsAPIModel;
            }
            return null;
        }

        public InnerPageModel GetInnerPageContents(IPublishedContent CurrentPage, UmbracoHelper _umbracoHelper, ServiceContext _serviceContext, IVariationContextAccessor _variationContextAccessor)
        {
            var pageModel = new InnerPageModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
            {
                Title = "Hi Jack",
                Description = "All requests to any 'innerPage' pages in the site will be'hijacked' and routed through the custom InnerPageController"
            };

            return pageModel;
        }
    }
}
