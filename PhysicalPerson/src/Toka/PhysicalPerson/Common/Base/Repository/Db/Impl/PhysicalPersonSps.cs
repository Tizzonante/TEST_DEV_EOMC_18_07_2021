using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Toka.BaseServices.Common.Model.Repository.Db;
using Toka.BaseServices.Common.Repository.Db;
using Toka.BaseServices.Common.Repository.Db.Impl;
using Toka.BaseServices.Infrastructure.Repository.Db.Impl;
using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Common.Base.Repository.Db.Impl
{
    public class PhysicalPersonSps<T> : BaseSpExecutor<T>, IPhysicalPersonSps<T> where T : class
    {
        public PhysicalPersonSps(IBaseRepositoryDataBase repoDatabase) : base(repoDatabase)
        {
            repoDatabase.SetDatabase(new TokaDbConnection());
        }

        public ResponseDb CreateNew(PhysicalPDb physicaldb, int UserId)
        {
            SqlParameter[] parameters = { new SqlParameter("@Nombre", physicaldb.Nombre),
                                          new SqlParameter("@ApellidoPaterno", physicaldb.ApellidoPaterno),
                                          new SqlParameter("@ApellidoMaterno", physicaldb.ApellidoMaterno),
                                          new SqlParameter("@RFC", physicaldb.RFC),
                                          new SqlParameter("@FechaNacimiento", physicaldb.FechaNacimiento),
                                          new SqlParameter("@UsuarioAgrega", UserId),
            };

            return InvokeStoreProcedureSingleResult<ResponseDb>("EXEC dbo.sp_AgregarPersonaFisica @Nombre=@Nombre, @ApellidoPaterno=@ApellidoPaterno, @ApellidoMaterno=@ApellidoMaterno, @RFC=@RFC, @FechaNacimiento=@FechaNacimiento, @UsuarioAgrega=@UsuarioAgrega",
                parameters);
        }

        public List<PhysicalPDb> GetAllPhysicalPersons()
        {
            int option = 1;
            int idPersona = 0;

            SqlParameter[] parameters = { new SqlParameter("@opt", option),
                                          new SqlParameter("@idP", idPersona) };

            return InvokeStoreProcedureWithResults<PhysicalPDb>("EXEC sp_ReadPersonaFisica @option=@opt, @idPersona=@idP", parameters)
                .ToList();
        }

        public T GetPhysicalPById(int idPhysicalPerson)
        {
            int option = 2;

            SqlParameter[] parameters = { new SqlParameter("@opt", option),
                                          new SqlParameter("@idP", idPhysicalPerson) };

            return InvokeStoreProcedureFirstResult("EXEC sp_ReadPersonaFisica @option=@opt, @idPersona=@idP", parameters);
        }

        public ResponseDb Update(PhysicalPDb physicaldb, int UserId)
        {
            SqlParameter[] parameters = { new SqlParameter("@Nombre", physicaldb.Nombre),
                                          new SqlParameter("@ApellidoPaterno", physicaldb.ApellidoPaterno),
                                          new SqlParameter("@ApellidoMaterno", physicaldb.ApellidoMaterno),
                                          new SqlParameter("@RFC", physicaldb.RFC),
                                          new SqlParameter("@FechaNacimiento", physicaldb.FechaNacimiento),
                                          new SqlParameter("@UsuarioAgrega", UserId),
                                          new SqlParameter("@IdPersonaFisica", physicaldb.IdPersonaFisica),
            };

            return InvokeStoreProcedureSingleResult<ResponseDb>("EXEC dbo.sp_ActualizarPersonaFisica @IdPersonaFisica=@IdPersonaFisica, @Nombre=@Nombre, @ApellidoPaterno=@ApellidoPaterno, @ApellidoMaterno=@ApellidoMaterno, @RFC=@RFC, @FechaNacimiento=@FechaNacimiento, @UsuarioAgrega=@UsuarioAgrega",
                parameters);
        }

        public ResponseDb Delete(int idPhysicalP)
        {
            SqlParameter[] parameters = { new SqlParameter("@IdPersonaFisica", idPhysicalP) };

            return InvokeStoreProcedureSingleResult<ResponseDb>("EXEC dbo.sp_EliminarPersonaFisica @IdPersonaFisica=@IdPersonaFisica", parameters);
        }
    }
}
