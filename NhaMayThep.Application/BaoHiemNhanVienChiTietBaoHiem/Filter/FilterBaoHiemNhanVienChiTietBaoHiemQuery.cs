﻿using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Filter
{
    public class FilterBaoHiemNhanVienChiTietBaoHiemQuery : IRequest<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? MaBaoHiemNhanVien { get; set; }
        public string? MaBaoHiemChiTiet { get; set; }
        public string? NhanVienId { get; set; }
        public int? LoaiBaoHiem { get; set; }
        public FilterBaoHiemNhanVienChiTietBaoHiemQuery() { }
        public FilterBaoHiemNhanVienChiTietBaoHiemQuery(
            int pageNumber,
            int pageSize,
            int? maBaoHiemNhanVien,
            string? maBaoHiemChiTiet,
            string? nhanVienId,
            int? loaiBaoHiem)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaBaoHiemNhanVien = maBaoHiemNhanVien;
            MaBaoHiemChiTiet = maBaoHiemChiTiet;
            NhanVienId = nhanVienId;
            LoaiBaoHiem = loaiBaoHiem;
        }
    }
}
