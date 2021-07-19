using Toka.BaseServices.Common.Model;

namespace Toka.WebApi.Common.Model
{
    public class HttpErrorResponse : BaseModel
    {
        public int InternalCode { get; set; }
        public string Message { get; set; }

        public HttpErrorResponse(int InternalCode, string Message)
        {
            this.InternalCode = InternalCode;
            this.Message = Message;
        }
    }
}