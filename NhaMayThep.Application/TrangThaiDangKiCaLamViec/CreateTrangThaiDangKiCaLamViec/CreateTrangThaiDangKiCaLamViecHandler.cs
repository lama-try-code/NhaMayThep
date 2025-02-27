﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec
{
    public class CreateTrangThaiDangKiCaLamViecHandler : IRequestHandler<CreateTrangThaiDangKiCaLamViecCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;
        public readonly IMapper _mapper;

        public CreateTrangThaiDangKiCaLamViecHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateTrangThaiDangKiCaLamViecCommand request, CancellationToken cancellationToken)
        {
            var exist = await _trangThaiDangKiCaLamViecRepository.FindAsync(x => x.Name == request.Name && !x.NgayXoa.HasValue, cancellationToken);
            if (exist != null)
            {
                return "Loại Trạng Thái trên đã tồn tại!";
            }

            var trangThai = new TrangThaiDangKiCaLamViecEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };
            _trangThaiDangKiCaLamViecRepository.Add(trangThai);
            return await _trangThaiDangKiCaLamViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Mới Thành Công" : "Tạo Mới Thất Bại";
        }
    }
}
