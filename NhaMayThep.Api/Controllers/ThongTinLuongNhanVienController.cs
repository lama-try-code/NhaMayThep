﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinLuongNhanVien;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetAll;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetById;
using NhaMayThep.Application.ThongTinLuongNhanVien.Update;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinLuongNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ThongTinLuongNhanVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinLuongNhanVienDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinLuongNhanVienDto>> CreateUser(
            [FromBody] CreateThongTinLuongNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinLuongNhanVienDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinLuongNhanVienDto>> UpdateUser(
            [FromBody] UpdateThongTinLuongNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinLuongNhanVienDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinLuongNhanVienDto>> DeleteUser(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinLuongNhanVienCommand(id), cancellationToken);
            return result;
        }

        [HttpGet("getByMSNV/{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinLuongNhanVienDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinLuongNhanVienDto>> GetUserById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinLuongNhanVienByMSNVQuery(id), cancellationToken);
            return result;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinLuongNhanVienDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ThongTinLuongNhanVienDto>>> GetAllUsers(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinLuongNhanVieQuery(), cancellationToken);
            return result;
        }
    }
}
