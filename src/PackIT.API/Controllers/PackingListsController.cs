using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Commands;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.API.Controllers;

public class PackingListsController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public PackingListsController(
		ICommandDispatcher commandDispatcher,
		IQueryDispatcher queryDispatcher
	)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[HttpGet("{Id:guid}")]
	public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result)!;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PackingListDto>>> Get(
		[FromQuery] SearchPackingLists query
	)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult> Post([FromBody] CreatePackingListWithItems command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{packingListId:guid}/items")]
	public async Task<ActionResult> Put([FromBody] AddPackingItem command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{packingListId:guid}/items/{name}/pack")]
	public async Task<ActionResult> Put([FromBody] PackItem command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{packingListId:guid}/items/{name}")]
	public async Task<ActionResult> Delete([FromBody] RemovePackingItem command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{packingListId:guid}")]
	public async Task<ActionResult> Delete([FromBody] RemovePackingList command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}
}
