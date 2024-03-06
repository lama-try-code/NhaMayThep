﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Update
{
    public class UpdateDangKiTangCaCommandHandler : IRequestHandler<UpdateDangKiTangCaCommand, DangKiTangCaDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiTangCaRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public UpdateDangKiTangCaCommandHandler(IMapper mapper, IDangKiTangCaRepository repository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<DangKiTangCaDto> Handle(UpdateDangKiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            var dangKiTangCa = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiTangCa == null)
            {
                throw new NotFoundException("DangKiTangCa does not exist or has been deleted.");
            }

           
            dangKiTangCa.MaSoNhanVien = request.MaSoNhanVien;
            dangKiTangCa.NgayLamTangCa = request.NgayLamTangCa;
            dangKiTangCa.CaDangKi = request.CaDangKi;
            dangKiTangCa.LiDoTangCa = request.LiDoTangCa;
            dangKiTangCa.ThoiGianCaLamBatDau = request.ThoiGianCaLamBatDau;
            dangKiTangCa.ThoiGianCaLamKetThuc = request.ThoiGianCaLamKetThuc;
            dangKiTangCa.SoGioTangCa = request.SoGioTangCa;
            dangKiTangCa.HeSoLuongTangCa = request.HeSoLuongTangCa;
            dangKiTangCa.TrangThaiDuyet = request.TrangThaiDuyet;
            dangKiTangCa.NguoiDuyet = request.NguoiDuyet;
            dangKiTangCa.NguoiCapNhatID = userId;
            dangKiTangCa.NgayCapNhatCuoi = DateTime.UtcNow;

            _repository.Update(dangKiTangCa);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DangKiTangCaDto>(dangKiTangCa);
        }
    }
}
