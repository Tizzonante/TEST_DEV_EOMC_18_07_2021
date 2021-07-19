using Toka.BaseServices.Common.Model;

namespace Toka.WebApi.Common.Base.Model.Dto
{
    public class BaseParamsBodyDto : BaseModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}