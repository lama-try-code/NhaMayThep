﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien
{
    public class NhanVienDto : IMapFrom<NhanVienEntity>
    {
        public NhanVienDto()
        {
            
        }
        public NhanVienDto(string iD, string email, string hoTen, string chucVu, string tinhTrangLamViec, DateTime ngayVaoCongTy, string diaChi, string soDienThoai, string maSoThue, string soTaiKhoan, string tenNganHang)
        {
            ID = iD;
            Email = email;
            HoVaTen = hoTen;
            ChucVu = chucVu;
            TinhTrangLamViec = tinhTrangLamViec;
            NgayVaoCongTy = ngayVaoCongTy;
            DiaChiLienLac = diaChi;
            SoDienThoaiLienLac = soDienThoai;
            MaSoThue = maSoThue;
            SoTaiKhoan = soTaiKhoan;
            TenNganHang = tenNganHang;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NhanVienEntity, NhanVienDto>();
        }

        public string ID { get; set; }
        public string Email { get; set; }
        public string HoVaTen { get; set; }
        public string ChucVu { get; set; }
        public string TinhTrangLamViec { get; set; }
        public DateTime NgayVaoCongTy { get; set; }
        public string DiaChiLienLac { get; set; }
        public string SoDienThoaiLienLac { get; set; }
        public string MaSoThue { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenNganHang { get; set; }
    }
}
