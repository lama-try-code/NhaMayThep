﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.BaoHiem
{
    public class BaoHiemDto : IMapFrom<BaoHiemEntity>
    {
        public BaoHiemDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public double PhanTramKhauTru { get; set; }
        public static BaoHiemDto Create(int id, string name, double phanTramKhauTru)
        {
            return new BaoHiemDto()
            {
                Id = id,
                Name = name,
                PhanTramKhauTru = phanTramKhauTru
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaoHiemEntity, BaoHiemDto>();
        }
    }
}
