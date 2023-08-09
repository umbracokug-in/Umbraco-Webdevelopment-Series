using DemoUmbraco.Core.Services;
using DemoUmbraco.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPoco.fastJSON;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Filters;
using static Umbraco.Cms.Core.Collections.TopoGraph;

namespace DemoUmbraco.Core.Controller
{
    public class DemoAPIController : UmbracoApiController
    {
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IPageContentService _iPageContentService;
        public DemoAPIController(UmbracoHelper umbracoHelper, IPageContentService iPageContentService)
        {
            _umbracoHelper = umbracoHelper;
            _iPageContentService = iPageContentService;
        }
        public string GetProductDetails(int nodeId = 1092)
        {
            /* Used to get the data without any authentication */
            //umbraco/api/DemoAPI/GetProductDetails ? nodeId=1092

            var responseModel = _iPageContentService.GetProductsDetails(nodeId, _umbracoHelper);
            var response = JsonSerializer.Serialize(responseModel);            
            return response;
        }


        [Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
        [Route("umbraco/backoffice/GetEditorContent/{nodeId?}")]
        public string GetEditorContent(int nodeId = 1098)
        {
            /*This will only allow a logged in backoffice user to access the Action:*/
            //It is important to know that this only works if the controller is routed to /umbraco/backoffice/
            var responseModel = _iPageContentService.GetMemberDetails(nodeId, _umbracoHelper);
            var response = JsonSerializer.Serialize(responseModel);
            return response;
        }


        
        //AllowType - Comma delimited list of allowed member types.
        //AllowGroup - Comma delimited list of allowed member groups.
        //AllowMembers - Comma delimited list of allowed members.

        [Route("umbraco/DemoAPI/GetTypeBasedContents/{nodeId?}")]
        [UmbracoMemberAuthorize("premiumUsers", "", "")]
        public string GetTypeBasedContents(int nodeId = 1098)
        {
            var responseModel = _iPageContentService?.GetNodeDetails(nodeId, _umbracoHelper);
            var response = JsonSerializer.Serialize(responseModel);
            return response;
        }

        [Route("umbraco/DemoAPI/GetGroupBasedContents/{nodeId?}")]
        [UmbracoMemberAuthorize("", "Platinum Members", "")]
        public string GetGroupBasedContents(int nodeId = 1098)
        {
            var responseModel = _iPageContentService.GetNodeDetails(nodeId, _umbracoHelper);
            var response = JsonSerializer.Serialize(responseModel);
            return response;
        }

        [Route("umbraco/DemoAPI/GetIDBasedContents/{nodeId?}")]
        [UmbracoMemberAuthorize("", "", "1084,1099")]
        public string GetIDBasedContents(int nodeId = 1098)
        {
            var responseModel = _iPageContentService.GetNodeDetails(nodeId, _umbracoHelper);
            var response = JsonSerializer.Serialize(responseModel);
            return response;
        }
    }
}
