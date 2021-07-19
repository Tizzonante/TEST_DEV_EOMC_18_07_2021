using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toka.WebApi.Common.Base.Model.Dto;
using Toka.WebApi.Common.Model;

namespace Toka.WebApi.Common.Base.Controller
{
    public class BaseController : ApiController
    {
        protected ILogger Log => LogManager.GetLogger(this.GetType().FullName);

        protected BaseController()
        {
            System.Web.HttpContext.Current.Server.ScriptTimeout = 300;
        }

        protected HttpResponseMessage GetErrorResponse(Exception ex, HttpStatusCode code)
        {
            HttpErrorResponse response = new HttpErrorResponse((int)code, ex.Message);
            return GetHttpErrorResponse(code, response);
        }

        protected HttpResponseMessage GetHttpResponse(HttpStatusCode code, object value)
        {
            HttpOkResponse json = new HttpOkResponse { Data = value, HttpCode = code };

            return Request.CreateResponse(code, json);
        }

        protected HttpResponseMessage GetHttpResponse(HttpStatusCode code)
        {
            return Request.CreateResponse(code);
        }

        protected HttpResponseMessage GetHttpErrorResponse(HttpStatusCode code, string message)
        {
            return Request.CreateErrorResponse(code, message);
        }

        protected HttpResponseMessage GetHttpErrorResponse(HttpStatusCode code, HttpErrorResponse errorResponse)
        {
            return Request.CreateResponse<HttpErrorResponse>(code, errorResponse);
        }
    }
}