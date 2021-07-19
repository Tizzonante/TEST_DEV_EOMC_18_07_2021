using System.IO;

namespace Toka.WebApi.Infrastructure.Constant
{
    public class TokaWebApiInfrastructureConst
    {
        public static readonly string APP_ROOT_PATH_ON_DISK = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";
        public static readonly string APPLICATION_ASSEMBLY_NAME = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
    }
}