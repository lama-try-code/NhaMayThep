﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateLoaiNghiPhepCommand, string>

    {
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;


        public CreateCommandHandler(INhanVienRepository hanVienRepository, ILoaiNghiPhepRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _hanVienRepository = hanVienRepository;
        }

        public async Task<string> Handle(CreateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tìm thấy");
            }

            var existingLoaiNghiPhep = await _repository.FindAllAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.NgayXoa == null);
            if (existingLoaiNghiPhep.Any())
            {

                throw new DuplicationException($"Loại Nghỉ Phép với tên này  '{request.Name}' đã có sẵn.");
            }


            var loaiNghiPhepEntity = new LoaiNghiPhepEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                Name = request.Name,

            };
            _repository.Add(loaiNghiPhepEntity);
            if (await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";


        }

    }
}