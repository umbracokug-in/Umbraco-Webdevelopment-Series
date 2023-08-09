using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace DemoUmbraco.Models.CustomModels
{
    public class InnerPageModel : PublishedContentWrapped
    {
        // PublishedContentWrapped will take care of populating all the usual underlying Umbraco properties
        // @Model.syntax will continue to work in the layouts used by your template.

        // The ProductPage model accepts an IPublishedContent item as a constructor
        
        public InnerPageModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {

        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
