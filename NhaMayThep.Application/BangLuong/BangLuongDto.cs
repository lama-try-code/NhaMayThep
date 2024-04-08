﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong
{
    public class BangLuongDto : IMapFrom<BangLuongEntity>
    {
        public BangLuongDto()
        {
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayKhaiBao { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal LuongTangCa { get; set; }

        public decimal LuongCoBan { get; set; }

        public decimal TongNhanCoDinh { get; set; }
        public double NgayCong { get; set; }
        public decimal TongThuNhap { get; set; }
        public decimal LuongDongBH { get; set; }

        public decimal TongBaoHiem { get; set; }
        public string PhuCapCongDoanID { get; set; }
        public string GiamTruNhanVienID { get; set; }
        public decimal TamUng { get; set; }
        public decimal LuongThucLanh { get; set; }
        public static BangLuongDto Create(string id, string maSoNhanVien, DateTime ngayKhaiBao, decimal luongNghiPhep, decimal luongTangCa, decimal luongCoBan,
                                          decimal tongNhanCoDinh, double ngayCong, decimal tongThuNhap, decimal luongDongBh,decimal tongBaoHiem, string phuCapCongDoanId, 
                                          string giamTruNhanVienId, decimal tamUng, decimal luongThucLanh)
                                            
        {
            return new BangLuongDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                NgayKhaiBao = ngayKhaiBao,
                LuongNghiPhep = luongNghiPhep,
                LuongTangCa = luongTangCa,

                LuongCoBan = luongCoBan,

                TongNhanCoDinh = tongNhanCoDinh,
                NgayCong = ngayCong,
                TongThuNhap = tongThuNhap,
                LuongDongBH = luongDongBh,

                TongBaoHiem = tongBaoHiem,
                PhuCapCongDoanID = phuCapCongDoanId,
                GiamTruNhanVienID = giamTruNhanVienId,
                TamUng = tamUng,
                LuongThucLanh = luongThucLanh
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BangLuongEntity, BangLuongDto>();
        }
    }
}
