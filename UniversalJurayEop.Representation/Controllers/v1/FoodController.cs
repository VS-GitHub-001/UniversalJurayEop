using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversalJurayEop.Application.Features.Foods.Commands.Create;
using UniversalJurayEop.Application.Features.Foods.Commands.Delete;
using UniversalJurayEop.Application.Features.Foods.Commands.Update;
using UniversalJurayEop.Application.Features.Foods.Queries.GetAll;
using UniversalJurayEop.Application.Features.Foods.Queries.GetById;

namespace UniversalJurayEop.Representation.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FoodController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFoodsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllFoodsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFoodByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateFoodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateFoodCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFoodByIdCommand { Id = id }));
        }
    }
}
