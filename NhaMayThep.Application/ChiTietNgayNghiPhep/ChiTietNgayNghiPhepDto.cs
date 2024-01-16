﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep
{
    public class ChiTietNgayNghiPhepDto : IMapFrom<ChiTietNgayNghiPhepEntity>
    {
        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhep { get; set; }
        public int TongSoGio { get; set; }
        public int SoGioDaNghiPhep { get; set; }
        public int SoGioConLai { get; set; }
        public int NamHieuLuoc { get; set; }
      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepDto>();

        }
    }
}
