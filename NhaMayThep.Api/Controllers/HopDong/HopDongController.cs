﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.HopDong;
using NhaMayThep.Application.HopDong.CreateNewHopDongCommand;
using NhaMayThep.Application.HopDong.DeleteHopDongCommand;
using NhaMayThep.Application.HopDong.GetAllHopDongQuery;
using NhaMayThep.Application.HopDong.GetHopDongByIdQuery;
using NhaMayThep.Application.HopDong.UpdateHopDongCommand;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.HopDong.HopDongApi
{
    [ApiController]
    public class HopDongController : ControllerBase
    {
        private readonly ISender _mediator;
        public HopDongController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("hop-dong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewHopDong([FromBody] CreateNewHopDongCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewHopDong), new { id = result }, new JsonResponse<string>(result));
        }

        [HttpDelete("hop-dong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> RemoveHopDong([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteHopDongCommand(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("hop-dong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<HopDongDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<HopDongDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<HopDongDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllHopDongQuery(), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("hop-dong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<HopDongDto>>> GetById([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHopDongByIdQuery(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }
        [HttpPut("hop-dong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<HopDongDto>>> UpdateHopDong([FromRoute] string id, [FromBody] UpdateHopDongCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Id == default)
                command.Id = id;
            if (id != command.Id)
                return BadRequest();
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
