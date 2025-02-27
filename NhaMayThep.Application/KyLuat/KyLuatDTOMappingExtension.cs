﻿using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.KyLuat
{
    public static class KyLuatDTOMappingExtension
    {
        public static KyLuatDTO MapToKyLuatDTO(this KyLuatEntity projectFrom, IMapper mapper)
           => mapper.Map<KyLuatDTO>(projectFrom);

        public static List<KyLuatDTO> MapToTinhKyLuatDTOList(this IEnumerable<KyLuatEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToKyLuatDTO(mapper)).ToList();
    }
}
