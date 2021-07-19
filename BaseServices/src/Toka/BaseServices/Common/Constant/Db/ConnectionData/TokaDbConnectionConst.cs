namespace Toka.BaseServices.Common.Constant.Db.ConnectionData
{
    public static class TokaDbConnectionConst
    {
        /// <summary>
        /// name or network address of the instance of SQL Server to connect to.
        /// </summary>
        public static readonly string Server = @"LAPTOP-KU1KVMBD\ERIKMONT_INST"; //"192.168.1.248"


        public static readonly string User = "sa";
        public static readonly string PassWord = "erik";
        public static readonly string DataBase = "TOKA";

        /// <summary>
        /// Name of your application to make a trace with sql profiler
        /// </summary>
        public readonly static string ApplicationName = "TokaAplicationWeb_EOMC";
    }
}
