﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.LuongSanPham;
using NhaMayThep.Application.LuongSanPham.Create;
using NhaMayThep.Application.LuongSanPham.Delete;
using NhaMayThep.Application.LuongSanPham.Filter;
using NhaMayThep.Application.LuongSanPham.GetAll;
using NhaMayThep.Application.LuongSanPham.GetId;
using NhaMayThep.Application.LuongSanPham.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    
    public class LuongSanPhamController : ControllerBase
    {
        private readonly ISender _mediator;

        public LuongSanPhamController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("luong-san-pham")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateLuongSanPham(
            [FromBody] CreateLuongSanPhamCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("luong-san-pham")]
        [ProducesResponseType(typeof(List<LuongSanPhamDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LuongSanPhamDto>>> GetAllLuongSanPham(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return Ok(new JsonResponse<List<LuongSanPhamDto>>(result));
        }

        [HttpPut("luong-san-pham")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLuongSanPham(

            [FromBody] UpdateLuongSanPhamCommand command,
            CancellationToken cancellationToken = default)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("luong-san-pham/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLuongSanPham(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteLuongSanPhamCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("luong-san-pham/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LuongSanPhamDto>>> GetLuongSanPhamById(string id, CancellationToken cancellationToken)
        {
            var query = new GetLuongSanPhamByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<LuongSanPhamDto>(result);
        }

        [HttpGet("luong-san-pham/filter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LuongSanPhamDto>>>> Filter(
            [FromQuery] FilterLuongSanPhamQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}