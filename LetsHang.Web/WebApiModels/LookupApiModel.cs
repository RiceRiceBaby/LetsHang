using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsHang.Web.WebApiModels
{
    public class LookupApiModel : BaseApiModel
    {
        public IList<LookupDTO> Lookups { get; set; }
    }

    public class LookupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}