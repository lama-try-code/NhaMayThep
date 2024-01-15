﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByID
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, LichSuNghiPhepDto>
    {
        private readonly ILichSuNghiPhepRepo _repo;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ILichSuNghiPhepRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<LichSuNghiPhepDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repo.FindByIdAsync(request.Id, cancellationToken);

            if (lsnp == null)
            {
                throw new NotFoundException($"LichSuNghiPhep with ID {request.Id} not found.");
            }

            return _mapper.Map<LichSuNghiPhepDto>(lsnp);
        }
    }
}
