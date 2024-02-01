﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommandHandler : IRequestHandler<UpdateThongTinDangVienCommand, string>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {
            

            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (thongTinDangVien == null)
                throw new NotFoundException("Không tìm thấy Đảng Viên");

            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!nhanVien)
                throw new NotFoundException("Không tìm thấy Nhân Viên");

            thongTinDangVien.NgayVaoDang = request.NgayVaoDang;
            thongTinDangVien.CapDangVien = request.CapDangVien ;
            thongTinDangVien.NguoiCapNhatID = _currentUserService.UserId;
            thongTinDangVien.NgayCapNhatCuoi = DateTime.Now;

            _thongTinDangVienRepository.Update(thongTinDangVien);
            if (await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
