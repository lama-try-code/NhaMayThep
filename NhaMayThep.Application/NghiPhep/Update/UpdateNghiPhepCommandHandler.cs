﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommandHandler : IRequestHandler<UpdateNghiPhepCommand, string>
    {
        private readonly INghiPhepRepository _nghiPhepRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepository;

        public UpdateNghiPhepCommandHandler(INghiPhepRepository nghiPhepRepository, IMapper mapper, ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepository)
        {
            _nghiPhepRepository = nghiPhepRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _loaiNghiPhepRepository = loaiNghiPhepRepository;
        }

        public async Task<string> Handle(UpdateNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nghiPhep = await _nghiPhepRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);
            if (nghiPhep == null)
            {
                throw new NotFoundException("Không tìm thấy hoặc bản ghi Nghỉ Phép đã bị xóa trước đó!");
            }
            var loaiNghiPhep = await _loaiNghiPhepRepository.FindAsync(x => x.ID == request.LoaiNghiPhepId, cancellationToken);
            if (loaiNghiPhep == null)
            {
                throw new NotFoundException("Loại nghỉ phép không tồn tại!");
            }

            nghiPhep.LuongNghiPhep = request.LuongNghiPhep;
            nghiPhep.KhoanTruLuong = request.KhoanTruLuong;
            nghiPhep.SoGioNghiPhep = request.SoGioNghiPhep;
            nghiPhep.LoaiNghiPhepID = request.LoaiNghiPhepId;
            nghiPhep.NguoiCapNhatID = _currentUserService.UserId;
            nghiPhep.NgayCapNhatCuoi = DateTime.Now;

            _nghiPhepRepository.Update(nghiPhep);
            //await _nghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            //return _mapper.Map<NghiPhepDto>(nghiPhep);
            if (await _nghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công!";
            else
                return "Cập nhật thất bại!";
        }
    }
}
