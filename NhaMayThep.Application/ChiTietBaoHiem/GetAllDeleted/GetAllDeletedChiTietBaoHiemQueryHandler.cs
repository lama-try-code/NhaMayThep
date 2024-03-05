﻿using AutoMapper;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using System.Diagnostics;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedChiTietBaoHiemQueryHandler: IRequestHandler<GetAllDeletedChiTietBaoHiemQuery, List<ChiTietBaoHiemDto>>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedChiTietBaoHiemQueryHandler(
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
        public async Task<List<ChiTietBaoHiemDto>> Handle(GetAllDeletedChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var result = await _chitietbaohiemRepository.FindAllAsync(x => x.NguoiXoaID != null && x.NgayXoa.HasValue, cancellationToken);
            if (result.Count == 0)
            {
                throw new NotFoundException("Không tồn tại bất kỳ chi tiết bảo hiểm nào bị xóa");
            }
            var tasks = result.Select(async x =>
            {
                var nhanvien = await _nhanvienRepository.FindAsync(_ => _.ID.Equals(x.MaSoNhanVien), cancellationToken);
                var baohiem = await _baohiemRepository.FindAsync(_ => _.ID == x.LoaiBaoHiem, cancellationToken);
                if (nhanvien != null && baohiem != null)
                {
                    return x.MapToChiTietBaoHiemDto(_mapper, nhanvien.HoVaTen, baohiem.Name);
                }
                else
                {
                    return x.MapToChiTietBaoHiemDto(_mapper, null, null);
                }
            });
            var mappedResults = await Task.WhenAll(tasks);

            return mappedResults.ToList();
        }
    }
}
