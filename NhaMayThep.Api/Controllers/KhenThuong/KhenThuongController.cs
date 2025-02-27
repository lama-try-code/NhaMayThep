﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.KhenThuong;
using NhaMayThep.Application.KhenThuong.CreateKhenThuong;
using NhaMayThep.Application.KhenThuong.DeleteKhenThuong;
using NhaMayThep.Application.KhenThuong.FilterKhenThuong;
using NhaMayThep.Application.KhenThuong.GetAllKhenThuong;
using NhaMayThep.Application.KhenThuong.GetByPagination;
using NhaMayThep.Application.KhenThuong.GetKhenThuongById;
using NhaMayThep.Application.KhenThuong.UpdateKhenThuong;
using NhaMayThep.Application.KyLuat;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.KhenThuong
{
    [ApiController]
    
    public class KhenThuongController : ControllerBase
    {
        private readonly ISender _mediator;
        public KhenThuongController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> createKhenThuong(
            [FromBody] CreateKhenThuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(createKhenThuong), new { id = result }, new JsonResponse<string>(result));
        }
        [HttpGet("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<KhenThuongDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<KhenThuongDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<KhenThuongDTO>>>> getAllKhenThuong(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllKhenThuongQuery(), cancellationToken);
            return new JsonResponse<List<KhenThuongDTO>>(result);
        }
        [HttpGet("KhenThuong/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KhenThuongDTO>>> getAllKhenThuong(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetKhenThuongByIDQuery(iD: Id), cancellationToken);
            return new JsonResponse<KhenThuongDTO>(result);
        }
        [HttpPut("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> updateKhenThuong(
            [FromBody] UpdateKhenThuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }
        [HttpDelete("KhenThuong/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> deleteKhenThuong(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new DeleteKhenThuongCommand(iD: Id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpGet("khen-thuong/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KhenThuongDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KhenThuongDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<KhenThuongDTO>>>> GetPagination([FromQuery] GetKhenThuongByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("khen-thuong/filter-khen-thuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KyLuatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<KyLuatDTO>>>> FilterKhenThuong(
        [FromQuery] FilterKhenThuongQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
