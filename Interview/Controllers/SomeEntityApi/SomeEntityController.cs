using Interview.DomainModel;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Interview.Controllers.SomeEntityApi
{
    public class SomeEntityController : ApiController
    {
        private readonly ISomeEntityService _someEntityService;

        public SomeEntityController(ISomeEntityService someEntityService)
        {
            _someEntityService = someEntityService;
        }

        [SwaggerResponse(System.Net.HttpStatusCode.OK, "List of entities", typeof(IEnumerable<SomeEntityApiModel>))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<ISomeEntity> entities;
            try
            {
                entities = await _someEntityService.GetAll();
            }
            catch (Exception ex)
            {
                // write ex to log

                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

            var models = entities?.Select(x => new SomeEntityApiModel(x));

            return Ok(models);
        }

        [SwaggerResponse(System.Net.HttpStatusCode.OK, "One entity by id", typeof(SomeEntityApiModel))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            ISomeEntity entity;
            try
            {
                entity = await _someEntityService.GetById(id);
            }
            catch (Exception ex)
            {
                // write ex to log

                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

            if (entity == null)
            {
                return NotFound();
            }

            var model = new SomeEntityApiModel(entity);

            return Ok(model);
        }

        [SwaggerResponse(System.Net.HttpStatusCode.OK, "Create", typeof(SomeEntityApiModel))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IHttpActionResult> Post([FromBody] CreateSomeEntityApiModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelToCreate = new SomeEntityApiModel(value);

            ISomeEntity result;
            try
            {
                result = await _someEntityService.Create(modelToCreate);
            }
            catch (Exception ex)
            {
                // write ex to log

                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

            var model = new SomeEntityApiModel(result);

            return Ok(model);
        }

        [SwaggerResponse(System.Net.HttpStatusCode.OK, "Update", typeof(SomeEntityApiModel))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IHttpActionResult> Put(Guid id, [FromBody] UpdateSomeEntityApiModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelToUpdate = new SomeEntityApiModel(value);

            ISomeEntity result;
            try
            {
                result = await _someEntityService.Update(id, modelToUpdate);
            }
            catch (Exception ex)
            {
                // write ex to log

                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

            if(result == null)
            {
                return NotFound();
            }

            var model = new SomeEntityApiModel(result);

            return Ok(model);
        }

        [SwaggerResponse(System.Net.HttpStatusCode.NoContent, "Delete by id")]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            ISomeEntity result;
            try
            {
                result = await _someEntityService.Delete(id);
            }
            catch (Exception ex)
            {
                // write ex to log

                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }
            if (result == null)
            {
                return NotFound();
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
