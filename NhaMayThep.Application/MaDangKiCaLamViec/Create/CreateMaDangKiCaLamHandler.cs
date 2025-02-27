﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Create
{
    public class CreateMaDangKiCaLamHandler : IRequestHandler<CreateMaDangKiCaLamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public CreateMaDangKiCaLamHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateMaDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var exist = await _maDangKiCaLamRepository.FindAsync(x => x.Name == request.Name && !x.NgayXoa.HasValue, cancellationToken);
            if (exist != null)
            {
                return "Loại Đăng Kí trên đã tồn tại!";
            }

            var dangKi = new MaDangKiCaLamEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };
            _maDangKiCaLamRepository.Add(dangKi);
            return await _maDangKiCaLamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Mới Thành Công" : "Tạo Mới Thất Bại";
        }
    }
}
