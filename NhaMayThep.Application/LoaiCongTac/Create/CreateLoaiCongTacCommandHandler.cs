﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommandHandler : IRequestHandler<CreateLoaiCongTacCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public CreateLoaiCongTacCommandHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateLoaiCongTacCommand request, CancellationToken cancellationToken)
        {
            var exist = await _loaiCongTacRepository.FindAsync(x => x.Name == request.Name && !x.NgayXoa.HasValue, cancellationToken);
            if (exist != null)
            {
                throw new NotFoundException("Loại Công Tác trên đã tồn tại!");
            }

            var loaiCongTac = new LoaiCongTacEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };
            _loaiCongTacRepository.Add(loaiCongTac);
            await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo Mới Thành Công";
        }
    }
}
