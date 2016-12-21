using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsHang.Web.WebApiModels
{
    public class BaseApiModel
    {
        private IList<String> _validationErrors = new List<String>();

        public IList<string> ValidationErrors
        {
            get { return _validationErrors; }
            set { _validationErrors = value; }
        }
    }
}