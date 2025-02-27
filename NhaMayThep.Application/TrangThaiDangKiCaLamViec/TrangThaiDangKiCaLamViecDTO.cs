﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec
{
    public class TrangThaiDangKiCaLamViecDTO : IMapFrom<TrangThaiDangKiCaLamViecEntity>
    {
        public TrangThaiDangKiCaLamViecDTO() { }

        public static TrangThaiDangKiCaLamViecDTO Create(int id, string name)
        {
            return new TrangThaiDangKiCaLamViecDTO
            {
                Id = id,
                Name = name,
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrangThaiDangKiCaLamViecEntity, TrangThaiDangKiCaLamViecDTO>();
        }
    }
}
