﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LichSuNghiPhep
{
    public class LichSuNghiPhepDto : IMapFrom<LichSuNghiPhepNhanVienEntity>
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhepID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LyDo { get; set; }
        public string NguoiDuyet { get; set; }
        public string TenNhanVien { get; set; }
        public string TenLoaiNghiPhep { get; set; }
        public string TenNguoiDuyet { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepDto>()
                .ForMember(dto => dto.TenNhanVien, opt => opt.MapFrom(entity => entity.NhanVien.HoVaTen))
                .ForMember(dto => dto.TenLoaiNghiPhep, opt => opt.MapFrom(entity => entity.LoaiNghiPhep.Name))
                .ForMember(dto => dto.TenNguoiDuyet, opt => opt.MapFrom(entity => entity.NguoiDuyetNhanVien.HoVaTen));
        }
    }
}
