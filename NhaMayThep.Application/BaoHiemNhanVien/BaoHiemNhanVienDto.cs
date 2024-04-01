﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.BaoHiemNhanVien
{
    public class BaoHiemNhanVienDto : IMapFrom<BaoHiemNhanVienEntity>
    {
        public BaoHiemNhanVienDto() { }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }

        public static BaoHiemNhanVienDto CreateBaoHiemNhanVien(string Id, string maSoNhanVien)
        {
            return new BaoHiemNhanVienDto()
            {
                ID = Id ,
                MaSoNhanVien = maSoNhanVien,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaoHiemNhanVienEntity, BaoHiemNhanVienDto>();
        }
    }
}
