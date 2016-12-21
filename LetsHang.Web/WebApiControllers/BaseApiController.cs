using LetsHang.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LetsHang.Web.WebApiControllers
{
    public class BaseApiController : ApiController
    {
        protected IAccountService AccountService { get; set; }
    }
}
