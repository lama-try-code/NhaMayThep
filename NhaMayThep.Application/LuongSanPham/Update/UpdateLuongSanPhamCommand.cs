﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommand : IRequest<string>, ICommand
    {
        public UpdateLuongSanPhamCommand(string id, string maSoNhanVien, int soSanPhamLam, string mucSanPhamID, decimal tongLuong, DateTime ngayKhaiBao)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPhamLam;
            MucSanPhamID = mucSanPhamID;
            TongLuong = tongLuong;
            NgayKhaiBao = ngayKhaiBao;
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public required string MucSanPhamID { get; set; }
        public decimal TongLuong { get; set; }
        public DateTime NgayKhaiBao { get; set; }
    }
}
