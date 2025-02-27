﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted
{
    public class GetAllPaginationDeletedChiTietBaoHiemQueryHandler : IRequestHandler<GetAllPaginationDeletedChiTietBaoHiemQuery, PagedResult<ChiTietBaoHiemDto>>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public GetAllPaginationDeletedChiTietBaoHiemQueryHandler(
            IChiTietBaoHiemRepository chiTietBaoHiemRepository,
            IMapper mapper,
            INhanVienRepository nhanVienRepository,
            IBaoHiemRepository baoHiemRepository)
        {
            _chitietbaohiemRepository = chiTietBaoHiemRepository;
            _mapper = mapper;
            _nhanvienRepository = nhanVienRepository;
            _baohiemRepository = baoHiemRepository;
        }
        public async Task<PagedResult<ChiTietBaoHiemDto>> Handle(GetAllPaginationDeletedChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var result = await _chitietbaohiemRepository.FindAllAsync(x
                => x.NguoiXoaID != null && x.NgayXoa.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tồn tại bất kỳ chi tiết bảo hiểm nào bị xóa");
            }
            var baohiems = await _baohiemRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            var data = result.MapToChiTietBaoHiemDtoList(_mapper, baohiems);
            return PagedResult<ChiTietBaoHiemDto>.Create(
               totalCount: result.TotalCount,
               pageCount: result.PageCount,
               pageSize: result.PageSize,
               pageNumber: result.PageNo,
               data: data.ToList());
        }
    }
}
