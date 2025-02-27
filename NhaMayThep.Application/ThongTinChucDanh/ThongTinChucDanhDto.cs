﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinChucDanh
{
    public class ChucDanhDto : IMapFrom<ThongTinChucDanhEntity>
    {
        public ChucDanhDto() { }

        public static ChucDanhDto Create(int id, string name)
        {
            return new ChucDanhDto()
            {
                Id = id,
                Name = name
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucDanhEntity, ChucDanhDto>();
        }

    }
}
