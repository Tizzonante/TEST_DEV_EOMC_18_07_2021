using System.Net;
using Toka.BaseServices.Common.Model;

namespace Toka.WebApi.Common.Base.Model.Dto
{
    public class HttpOkResponse : BaseModel
    {
        public HttpStatusCode HttpCode { get; set; }
        public object Data { get; set; }
    }
}