﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.LoaiCongTac;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByPagination
{
    public class GetLichSuCongTacNhanVienByPaginationQueryHandler : IRequestHandler<GetLichSuCongTacNhanVienByPaginationQuery, PagedResult<LichSuCongTacNhanVienDto>>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;

        public GetLichSuCongTacNhanVienByPaginationQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<PagedResult<LichSuCongTacNhanVienDto>> Handle(GetLichSuCongTacNhanVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            foreach (var item in list)
                item.LoaiCongTac.MapToLoaiCongTacDto(_mapper);

            var result = list.MapTolichSuCongTacNhanVienDtoList(_mapper);

            foreach (var item in result)
            {
                var nameSearching = await _nhanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien), cancellationToken);
                item.HoVaTen = nameSearching.HoVaTen;
            }

            return PagedResult<LichSuCongTacNhanVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: result
                );
        }
    }
}
