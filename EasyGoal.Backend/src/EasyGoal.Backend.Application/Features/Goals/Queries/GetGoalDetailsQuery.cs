﻿using EasyGoal.Backend.Application.Features.Goals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed record GetGoalDetailsQuery(Guid Id) : IRequest<GoalDetailsDto>
{
}
