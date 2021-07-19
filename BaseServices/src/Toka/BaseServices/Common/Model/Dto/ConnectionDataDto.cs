namespace Toka.BaseServices.Common.Model.Dto
{
    public class ConnectionDataDto : BaseModel
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string PassWord { get; set; }
        public string DataBase { get; set; }
        public string ApplicationName { get; set; }
    }
}
