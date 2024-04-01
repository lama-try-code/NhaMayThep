﻿using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Filter
{
    public class FilterLuongSanPhamQuery : IRequest<PagedResult<LuongSanPhamDto>>, IQuery
    {
        public FilterLuongSanPhamQuery()
        {
        }

        public FilterLuongSanPhamQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }

        public FilterLuongSanPhamQuery(int pageNo, int pageSize, string? maSoNhanVien, int? soSanPhamLam, string? mucSanPham) : this(pageNo, pageSize)
        {
            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPhamLam;
            MucSanPham = mucSanPham;
        }

        public int PageNo {  get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? SoSanPhamLam { get; set; }
        public string? MucSanPham { get; set; }
    }
}
