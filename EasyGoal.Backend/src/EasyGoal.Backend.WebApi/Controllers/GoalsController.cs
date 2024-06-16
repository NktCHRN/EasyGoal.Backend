﻿using AutoMapper;
using EasyGoal.Backend.Application.Features.Goals.Commands;
using EasyGoal.Backend.WebApi.Contracts.Requests.Goals;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using EasyGoal.Backend.WebApi.Contracts.Responses.Goals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public sealed class GoalsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GoalsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<GoalCreatedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateGoal([FromBody] CreateGoalRequest request)
    {
        var command = _mapper.Map<CreateGoalCommand>(request);

        var result = await _mediator.Send(command);

        var response = _mapper.Map<GoalCreatedResponse>(result);

        return OkResponse(response);
    }

    [HttpPut("{goalId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateGoal([FromRoute] Guid goalId, [FromBody] UpdateGoalRequest request)
    {
        var command = _mapper.Map<UpdateGoalCommand>(request);
        command.Id = goalId;

        await _mediator.Send(command);

        return NoContentResponse();
    }

    [HttpDelete("{goalId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteGoal([FromRoute] Guid goalId)
    {
        var command = new DeleteGoalCommand(goalId);

        await _mediator.Send(command);

        return NoContentResponse();
    }
}
