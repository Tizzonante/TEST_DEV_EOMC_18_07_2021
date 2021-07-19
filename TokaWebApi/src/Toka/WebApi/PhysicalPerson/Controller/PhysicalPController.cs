using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toka.PhysicalPerson.Common.Model;
using Toka.PhysicalPerson.Create.Service;
using Toka.PhysicalPerson.Read.Service;
using Toka.WebApi.Common.Base.Controller;
using Toka.WebApi.PhysicalPerson.Model;
using System.Linq;
using System.Collections.Generic;
using Toka.PhysicalPerson.Update.Service;
using Toka.PhysicalPerson.Delete.Service;
using Toka.BaseServices.Common.Exceptions;
using Toka.BaseServices.Common.Constant.Messages;

namespace TokaWebApi.src.Toka.WebApi.PhysicalPerson.Controller
{
    [RoutePrefix("PhysicalP")]
    public class PhysicalPController : BaseController
    {
        private IPhysicalPCreateService physicalPCreator;
        private IPhysicalPReadService physicalPRead;
        private IPhysicalPUpdateService physicalPUpdate;
        private IPhysicalPDeleteService physicalPDelete;     

        public PhysicalPController(IPhysicalPCreateService physicalPCreator, IPhysicalPReadService physicalPRead,
            IPhysicalPUpdateService physicalPUpdate, IPhysicalPDeleteService physicalPDelete)
        {
            this.physicalPCreator = physicalPCreator;
            this.physicalPRead = physicalPRead;
            this.physicalPUpdate = physicalPUpdate;
            this.physicalPDelete = physicalPDelete;
        }

        //http://localhost:61631/PhysicalP/GetAll/?UserId=1
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage Read([FromUri] PhysicalPersonDtoApi request)
        {
            try
            {
                List<PhysicalPersonDtoApiResponse> response = null;

                Log.Debug("{0} Getting all physical persons", request.UserId);
                var responseDb = physicalPRead.GetAll();

                if (null != responseDb)
                {
                    response = responseDb.Select(x => new PhysicalPersonDtoApiResponse
                    {
                        Names = x.Nombre,
                        RFC = x.RFC,
                        PhysicalPersonId = x.IdPersonaFisica,
                        LastNameMother = x.ApellidoMaterno,
                        LastNameFather = x.ApellidoPaterno,
                        BirthDate = x.FechaNacimiento,
                        IsActive = x.Activo,
                        RegistryDate = x.FechaRegistro,
                        UpdateDate = x.FechaActualizacion
                    }).ToList();

                    return GetHttpResponse(HttpStatusCode.OK, response);
                }

                return GetHttpResponse(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return GetHttpErrorResponse(HttpStatusCode.InternalServerError, BaseExceptionMsgConstant.EXCEPTION_INTERNA_MESSAGE);
            }
        }

        //http://localhost:61631/PhysicalP/GetbyId/?UserId=1&PhysicalPersonId=2
        [Route("GetbyId")]
        [HttpGet]
        public HttpResponseMessage ReadById([FromUri] PhysicalPersonDtoApi request)
        {
            try
            {
                PhysicalPersonDtoApiResponse physicalPersonDtoApi = null;

                Log.Debug("{0} Getting info of physical persons with id: {1}", request.UserId, request.PhysicalPersonId);
                var responseDb = physicalPRead.GetById(request.PhysicalPersonId);

                if (null != responseDb)
                {
                    physicalPersonDtoApi = new PhysicalPersonDtoApiResponse
                    {
                        Names = responseDb.Nombre,
                        RFC = responseDb.RFC,
                        PhysicalPersonId = responseDb.IdPersonaFisica,
                        LastNameMother = responseDb.ApellidoMaterno,
                        LastNameFather = responseDb.ApellidoPaterno,
                        BirthDate = responseDb.FechaNacimiento,
                        IsActive = responseDb.Activo,
                        RegistryDate = responseDb.FechaRegistro,
                        UpdateDate = responseDb.FechaActualizacion
                    };
                    return GetHttpResponse(HttpStatusCode.OK, physicalPersonDtoApi);
                }

                return GetHttpResponse(HttpStatusCode.BadRequest, physicalPersonDtoApi);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return GetHttpErrorResponse(HttpStatusCode.InternalServerError, BaseExceptionMsgConstant.EXCEPTION_INTERNA_MESSAGE);
            }
        }

        //http://localhost:61631/PhysicalP/Create
        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage CreateNew([FromBody] PhysicalPersonDtoApi request)
        {
            try
            {
                PhysicalPersonDtoApiResponse physicalPersonDtoApi = null;

                Log.Debug("{0} Creating a new physical person with name:  {1}", request.UserId,
                 String.Concat(request.Names, " ", request.LastNameFather, " ", request.LastNameMother));

                PhysicalPDb physicalPDb = new PhysicalPDb
                {
                    Nombre = request.Names,
                    ApellidoMaterno = request.LastNameMother,
                    ApellidoPaterno = request.LastNameFather,
                    FechaNacimiento = request.BirthDate,
                    RFC = request.RFC
                };

                PhysicalPDb responseDb = physicalPCreator.CreateNew(physicalPDb, request.UserId);

                if (null != responseDb)
                {
                    physicalPersonDtoApi = new PhysicalPersonDtoApiResponse
                    {
                        Names = responseDb.Nombre,
                        RFC = responseDb.RFC,
                        PhysicalPersonId = responseDb.IdPersonaFisica,
                        LastNameMother = responseDb.ApellidoMaterno,
                        LastNameFather = responseDb.ApellidoPaterno,
                        BirthDate = responseDb.FechaNacimiento,
                        IsActive = responseDb.Activo,
                        RegistryDate = responseDb.FechaRegistro,
                        UpdateDate = responseDb.FechaActualizacion
                    };
                }

                return GetHttpResponse(HttpStatusCode.OK, physicalPersonDtoApi);
            }
            catch (TokaBaseException tokaException)
            {
                Log.Warn(tokaException);
                return GetHttpErrorResponse(HttpStatusCode.BadRequest, tokaException.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return GetHttpErrorResponse(HttpStatusCode.InternalServerError, BaseExceptionMsgConstant.EXCEPTION_INTERNA_MESSAGE);
            }
        }

        //http://localhost:61631/PhysicalP/Update
        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody] PhysicalPersonDtoApi request)
        {
            try
            {
                PhysicalPersonDtoApiResponse physicalPersonDtoApi = null;

                Log.Debug("{0} Update a physical person with new name:  {1}", request.UserId,
                 String.Concat(request.Names, " ", request.LastNameFather, " ", request.LastNameMother));

                PhysicalPDb physicalPDb = new PhysicalPDb
                {
                    Nombre = request.Names,
                    ApellidoMaterno = request.LastNameMother,
                    ApellidoPaterno = request.LastNameFather,
                    FechaNacimiento = request.BirthDate,
                    RFC = request.RFC,
                    IdPersonaFisica = request.PhysicalPersonId
                };

                PhysicalPDb responseDb = physicalPUpdate.Update(physicalPDb, request.UserId);


                physicalPersonDtoApi = new PhysicalPersonDtoApiResponse
                {
                    Names = responseDb.Nombre,
                    RFC = responseDb.RFC,
                    PhysicalPersonId = responseDb.IdPersonaFisica,
                    LastNameMother = responseDb.ApellidoMaterno,
                    LastNameFather = responseDb.ApellidoPaterno,
                    BirthDate = responseDb.FechaNacimiento,
                    IsActive = responseDb.Activo,
                    RegistryDate = responseDb.FechaRegistro,
                    UpdateDate = responseDb.FechaActualizacion
                };

                return GetHttpResponse(HttpStatusCode.OK, physicalPersonDtoApi);
            }
            catch (TokaBaseException tokaException)
            {
                Log.Warn(tokaException);
                return GetHttpErrorResponse(HttpStatusCode.BadRequest, tokaException.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return GetHttpErrorResponse(HttpStatusCode.InternalServerError, BaseExceptionMsgConstant.EXCEPTION_INTERNA_MESSAGE);
            }
        }

        //http://localhost:61631/PhysicalP/Update
        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] PhysicalPersonDtoApi request)
        {
            try
            {
                Log.Debug("{0} Delete a physical person with Id:  {1}", request.UserId, request.PhysicalPersonId);

                PhysicalPDb responseDb = physicalPDelete.Delete(request.PhysicalPersonId, request.UserId);

                var physicalPersonDtoApi = new
                {
                    PhysicalPersonId = responseDb.IdPersonaFisica
                };

                return GetHttpResponse(HttpStatusCode.OK, physicalPersonDtoApi);
            }
            catch (TokaBaseException tokaException)
            {
                Log.Warn(tokaException);
                return GetHttpErrorResponse(HttpStatusCode.BadRequest, tokaException.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return GetHttpErrorResponse(HttpStatusCode.InternalServerError, BaseExceptionMsgConstant.EXCEPTION_INTERNA_MESSAGE);
            }
        }
    }
}
