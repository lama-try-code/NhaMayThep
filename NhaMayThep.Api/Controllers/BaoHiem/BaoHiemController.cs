﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.BaoHiem;
using NhaMayThep.Application.BaoHiem.CreateNewBaoHiem;
using NhaMayThep.Application.BaoHiem.FilterBaoHiem;
using NhaMayThep.Application.BaoHiem.GetAllBaoHiem;
using NhaMayThep.Application.BaoHiem.GetBaoHiemById;
using NhaMayThep.Application.BaoHiem.GetPaginationBaoHiem;
using NhaMayThep.Application.BaoHiem.RemoveBaoHiem;
using NhaMayThep.Application.BaoHiem.UpdateBaoHiem;
using NhaMayThep.Application.Common.Pagination;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.BaoHiem
{
    [ApiController]
    

    public class BaoHiemController : ControllerBase
    {
        private ISender _mediator;
        public BaoHiemController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("bao-hiem")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<BaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<BaoHiemDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BaoHiemDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllBaoHiemQuery(), cancellationToken);
            return Ok(new JsonResponse<List<BaoHiemDto>>(result));
        }

        [HttpGet("bao-hiem/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<BaoHiemDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<BaoHiemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BaoHiemDto>> GetId([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetBaoHiemByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<BaoHiemDto>(result));
        }

        [HttpPost("bao-hiem")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> CreateNew([FromBody] CreateNewBaoHiemCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("bao-hiem/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Remove([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new RemoveBaoHiemCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("bao-hiem")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Update([FromBody] UpdateBaoHiemCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("bao-hiem/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemDto>>>> GetPagination([FromQuery] GetBaoHiemByPagination query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("bao-hiem/filter-bao-hiem")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemDto>>>> FilterBaoHiem(
            [FromQuery] FilterBaoHiemQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<PagedResult<BaoHiemDto>>(query, cancellationToken);
            return Ok(result);
        }
    }
}
