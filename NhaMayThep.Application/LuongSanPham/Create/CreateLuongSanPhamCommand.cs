﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommand : IRequest<string>, ICommand
    {
        public CreateLuongSanPhamCommand(string id, string maSoNhanVien, int soSanPham, int mucSanPhamID, decimal tongLuong)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPham;
            MucSanPhamID = mucSanPhamID;
            TongLuong = tongLuong;
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public required int MucSanPhamID { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }
    }
}