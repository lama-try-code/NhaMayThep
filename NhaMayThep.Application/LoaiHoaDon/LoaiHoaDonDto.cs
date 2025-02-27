﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LoaiHoaDon
{
    public class LoaiHoaDonDto : IMapFrom<LoaiHoaDonEntity>
    {
        public LoaiHoaDonDto() { }

        public static LoaiHoaDonDto create(int id, string name)
        {
            return new LoaiHoaDonDto
            {
                Id = id,
                Name = name,
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiHoaDonEntity, LoaiHoaDonDto>();
        }
    }
}
