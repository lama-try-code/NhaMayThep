﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien
{
    public class HoaDonCongTacNhanVienDto : IMapFrom<HoaDonCongTacNhanVienEntity>
    {

        public static HoaDonCongTacNhanVienDto create(string lichSuCongTacID, string duongDanFile, int loaiHoaDon)
        {
            return new HoaDonCongTacNhanVienDto
            {
                DuongDanFile = duongDanFile,
                LoaiHoaDonID = loaiHoaDon,
                LichSuCongTacID = lichSuCongTacID,
            };
        }

        public required string LichSuCongTacID { get; set; }

        public required int LoaiHoaDonID { get; set; }

        public required string DuongDanFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HoaDonCongTacNhanVienEntity, HoaDonCongTacNhanVienDto>();
        }
    }
}
