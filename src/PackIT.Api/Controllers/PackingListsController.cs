using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Commands;
using PackIT.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Api.Controllers
{
    public class PackingListsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PackingListsController(IQueryDispatcher query,
                                      ICommandDispatcher command)
        {
            _queryDispatcher = query;
            _commandDispatcher = command;
        }

        #region Queries
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
        {
            var results = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(results);
        }
        #endregion


        #region Commands
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPut("{PackingListId}/item")]
        public async Task<IActionResult> Put([FromBody] AddPackingItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("{PackingListId:guid}/item/{name}/pack")]
        public async Task<IActionResult> Put([FromBody] PackItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{PackingListId:guid}/item/{name}")]
        public async Task<IActionResult> Delete([FromBody] RemovePackingItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] RemovePackingList command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        } 
        #endregion
    }
}
