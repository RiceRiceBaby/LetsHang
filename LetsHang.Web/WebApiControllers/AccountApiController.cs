using LetsHang.Domain.DomainModels;
using LetsHang.Domain.Exceptions;
using LetsHang.Domain.IServices;
using LetsHang.Web.WebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LetsHang.Web.WebApiControllers
{
    [RoutePrefix("WebApi/Account")]
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(IAccountService accountService)
        {
            this.AccountService = accountService;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(HttpRequestMessage request, [FromBody] UserDM user)
        {
            HttpStatusCode code = HttpStatusCode.OK;
            AccountApiModel model = new AccountApiModel();

            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;

            try
            {
                AccountService.RegisterUser(user);
            }
            catch (ValidationException ex)
            {
                model.ValidationErrors = user.ValidationErrors;
                code = HttpStatusCode.NotAcceptable;
            }
            catch (Exception ex)
            {
                model.ValidationErrors.Add("Save failed. An internal server error occurred.");
                code = HttpStatusCode.InternalServerError;
            }

            return Request.CreateResponse(code, model);
        }
    }
}
