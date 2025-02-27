﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommandHandler : IRequestHandler<RestoreThongTinCongDoanCommand, string>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public RestoreThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<string> Handle(RestoreThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository
                .FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID != null && x.NgayXoa.HasValue, cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException("Thông tin công đoàn không tồn tại");
            }
            thongtincongdoan.NguoiXoaID = null;
            thongtincongdoan.NgayXoa = null;
            thongtincongdoan.NguoiCapNhatID = _currentUserService.UserId;
            thongtincongdoan.NgayCapNhatCuoi = DateTime.Now;
            _thongtinCongDoanRepository.Update(thongtincongdoan);
            return await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Phục hồi thành công" : "Phục hồi thất bại";
        }
    }
}
