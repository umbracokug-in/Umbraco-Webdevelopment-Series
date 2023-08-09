using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUmbraco.Models.Models.CustomModels
{
    public class ProductAPIModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Capacity { get; set; }
        public string? Colour { get; set; }
        public string? Price { get; set; }
    }
    
    public class MemberAPIModel
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Region { get; set; }
        public string? Designation { get; set; }
    }

    public class NodeDetailsAPIModel
    {
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public string? ContentType { get; set; }
        public string? CreatedOn { get; set; }
    }
}
