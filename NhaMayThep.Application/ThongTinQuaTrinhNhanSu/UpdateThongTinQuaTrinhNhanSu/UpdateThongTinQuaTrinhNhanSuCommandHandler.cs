﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.UpdateThongTinQuaTrinhNhanSu
{
    public class UpdateThongTinQuaTrinhNhanSuCommandHandler : IRequestHandler<UpdateThongTinQuaTrinhNhanSuCommand, string>
    {
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinQuaTrinhNhanSuCommandHandler(ICurrentUserService currentUserService, IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _currentUserService = currentUserService;
            _thongTinQuaTrinhNhanSuRepository = thongTinQuaTrinhNhanSuRepository;
        }
        public async Task<string> Handle(UpdateThongTinQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _thongTinQuaTrinhNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("ID: " + command.ID + " không tồn tại");
            }
            var existName = await _thongTinQuaTrinhNhanSuRepository.AnyAsync(x => x.Name == command.Name && x.ID != command.ID && x.NguoiXoaID == null, cancellationToken);
            if (existName == true)
            {
                throw new DuplicateNameException("Thông tin quá trình nhân sự: " + command.Name + " đã tồn tại");
            }
            entity.Name = command.Name;
            entity.NgayCapNhat = DateTime.UtcNow;
            entity.NguoiCapNhatID = _currentUserService.UserId;
            _thongTinQuaTrinhNhanSuRepository.Update(entity);
            return await _thongTinQuaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
