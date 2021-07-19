﻿using System.IO;

namespace Toka.PhysicalPerson.Infrastructure.Constant
{
    public static class PhysicalPersonInfrastructureConst
    {
        public static readonly string APP_ROOT_PATH_ON_DISK = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";
        public static readonly string APPLICATION_ASSEMBLY_NAME = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
    }
}
