﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.UpdateCanCuocCongDan
{
    public class UpdateCanCuocCongDanCommandHandler : IRequestHandler<UpdateCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository, ICurrentUserService currentUserService)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.ID == request.CanCuocCongDanID && x.NgayXoa == null, cancellationToken) ?? throw new NotFoundException("Nhân Viên Không Có Cân Cước Công Dân");

            CanCuocCongDan.CanCuocCongDan = request.CanCuocCongDan;
            CanCuocCongDan.HoVaTen = request.HoVaTen;
            CanCuocCongDan.NgaySinh = request.NgaySinh;
            CanCuocCongDan.GioiTinh = request.GioiTinh;
            CanCuocCongDan.QuocTich = request.QuocTich;
            CanCuocCongDan.QueQuan = request.QueQuan;
            CanCuocCongDan.DiaChiThuongTru = request.DiaChiThuongTru;
            CanCuocCongDan.NgayCap = request.NgayCap;
            CanCuocCongDan.NoiCap = request.NoiCap;
            CanCuocCongDan.DanToc = request.DanToc;
            CanCuocCongDan.TonGiao = request.TonGiao;
            CanCuocCongDan.NgayCapNhatCuoi = DateTime.Now;
            CanCuocCongDan.NguoiCapNhatID = _currentUserService.UserId;
            _canCuocCongDanRepository.Update(CanCuocCongDan);
            return await _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cap Nhat Thanh Cong" : "Cap Nhat That Bai";
        }
    }

}

