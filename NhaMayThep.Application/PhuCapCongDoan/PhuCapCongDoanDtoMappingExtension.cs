﻿using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.PhuCapCongDoan
{
    public static class PhuCapCongDoanDtoMappingExtension
    {
        public static PhuCapCongDoanDto MapToPhuCapCongDoanDto(this PhuCapCongDoanEntity projectFrom, IMapper mapper)
            => mapper.Map<PhuCapCongDoanDto>(projectFrom);

        public static List<PhuCapCongDoanDto> MapToPhuCapCongDoanDtoList(this IEnumerable<PhuCapCongDoanEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPhuCapCongDoanDto(mapper)).ToList();
    }
}
