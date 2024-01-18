using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinCongTy.GetThongTinCongTyById
{
    public class GetThongTinCongTyByIdQueryHandler : IRequestHandler<GetThongTinCongTyByIdQuery, ThongTinCongTyDto>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly IMapper _mapper;

        public GetThongTinCongTyByIdQueryHandler(IThongTinCongTyRepository thongTinCongTyRepository, IMapper mapper)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _mapper = mapper;
        }

        public async Task<ThongTinCongTyDto> Handle(GetThongTinCongTyByIdQuery request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository.FindAsync(t => t.ID == request.Id,cancellationToken);

            if (thongTinCongTy is null || thongTinCongTy.NgayXoa is not null)
                throw new NotFoundException($"Khong tim thay Id {request.Id}");

            return thongTinCongTy.MapToThongTinCongTyDto(_mapper);
        }
    }
}