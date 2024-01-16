﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandHandler : IRequestHandler<UpdateThongTinLuongNhanVienCommand, ThongTinLuongNhanVienDto>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;

        public UpdateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(UpdateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var thongtin = await _thongTinLuongNhanVienRepository.FindByIdAsync(request.Id, cancellationToken);

            if (thongtin == null || thongtin.NgayXoa != null)
            {
                throw new NotFoundException("Thong tin not found");
            }

            var nhanvien = await _nhanVienRepository.FindByIdAsync(request.MaSoNhanVien.ToString(), cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }

            var hopdong = await _hopDongRepository.FindByIdAsync(request.MaSoHopDong.ToString(), cancellationToken);

            if (hopdong == null)
            {
                throw new NotFoundException("Hop dong not found");
            }


            thongtin.MaSoNhanVien = request.MaSoNhanVien == null ? thongtin.MaSoNhanVien : request.MaSoNhanVien;
            thongtin.MaSoHopDong = request.MaSoHopDong == null ? thongtin.MaSoHopDong : request.MaSoHopDong;
            thongtin.Loai = request.Loai == null ? thongtin.Loai : request.Loai;
            thongtin.LuongCu = request.LuongCu == null ? thongtin.LuongCu : request.LuongCu;
            thongtin.LuongHienTai = request.LuongHienTai == null ? thongtin.LuongHienTai : request.LuongHienTai;
            thongtin.NgayHieuLuc = request.NgayHieuLuc == null ? thongtin.NgayHieuLuc : request.NgayHieuLuc;



            _thongTinLuongNhanVienRepository.Update(thongtin);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return thongtin.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
