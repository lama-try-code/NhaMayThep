﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQueryHandler : IRequestHandler<GetThongTinCongDoanByNhanVienIdQuery, ThongTinCongDoanDto>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        public GetThongTinCongDoanByNhanVienIdQueryHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinCongDoanDto> Handle(GetThongTinCongDoanByNhanVienIdQuery request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository
                .FindAsync(x => x.NhanVienID.Equals(request.Id) && x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);
            if (thongtincongdoan == null || thongtincongdoan.NhanVien.NgayXoa.HasValue && thongtincongdoan.NhanVien.NguoiXoaID != null)
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công đoàn nào cho nhân viên này");
            }
            return thongtincongdoan.MapToThongTinCongDoanDto(_mapper, thongtincongdoan.NhanVien.HoVaTen ?? "Trống");
        }
    }
}
