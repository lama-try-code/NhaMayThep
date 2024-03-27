﻿using MediatR;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommand : IRequest<string>, ICommand
    {
        public UpdateLuongSanPhamCommand(string id, string maSoNhanVien, int soSanPhamLam, string mucSanPhamID, decimal tongLuong)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPhamLam;
            MucSanPhamID = mucSanPhamID;
            TongLuong = tongLuong;
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public required string MucSanPhamID { get; set; }
        public decimal TongLuong { get; set; }
    }
}
