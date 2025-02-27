﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu.GetChucVuById
{
    public class GetChucVuByIdQueryHandler : IRequestHandler<GetChucVuByIdQuery, ChucVuDto>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetChucVuByIdQueryHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<ChucVuDto> Handle(GetChucVuByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _chucVuRepository.FindAsync(x => x.ID == query.ID && x.NgayXoa == null, cancellationToken);

            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Không tìm thấy chức vụ với id: {query.ID}");
            return result.MapToChucVuDto(_mapper);
        }
    }
}
