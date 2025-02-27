﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiTangCa
{
    public static class LoaiTangCaDtoMappingExtension
    {
        public static LoaiTangCaDto MapToLoaiTangCaDto(this LoaiTangCaEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LoaiTangCaDto>(projectfrom);

        }
        public static List<LoaiTangCaDto> MapToLoaiTangCaDtoList(this IEnumerable<LoaiTangCaEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLoaiTangCaDto(mapper)).ToList();
    }
}
