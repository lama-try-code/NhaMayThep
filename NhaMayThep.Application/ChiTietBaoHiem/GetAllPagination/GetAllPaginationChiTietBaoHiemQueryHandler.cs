﻿using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMapThep.Domain.Common.Exceptions;
using System.Diagnostics;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPagination
{
    public class GetAllPaginationChiTietBaoHiemQueryHandler : IRequestHandler<GetAllPaginationChiTietBaoHiemQuery, PagedResult<ChiTietBaoHiemDto>>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public GetAllPaginationChiTietBaoHiemQueryHandler(
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
        public async Task<PagedResult<ChiTietBaoHiemDto>> Handle(GetAllPaginationChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var result = await _chitietbaohiemRepository.FindAllAsync(x
                => x.NguoiXoaID == null && !x.NgayXoa.HasValue, request.PageNumber,request.PageSize,cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tồn tại bất kỳ chi tiết bảo hiểm nào");
            }
            var baohiems = await _baohiemRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            var data= result.MapToChiTietBaoHiemDtoList(_mapper, baohiems);
            return PagedResult<ChiTietBaoHiemDto>.Create(
               totalCount: result.TotalCount,
               pageCount: result.PageCount,
               pageSize: result.PageSize,
               pageNumber: result.PageNo,
               data: data.ToList());
        }
    }
}
