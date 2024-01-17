﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommandHandler : IRequestHandler<CreateThongTinGiamTruCommand, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTruReposiyory _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinGiamTruCommandHandler(IThongTinGiamTruReposiyory repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public CreateThongTinGiamTruCommandHandler() { }
        public async Task<ThongTinGiamTruDTO> Handle(CreateThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = new ThongTinGiamTruEntity
            {
                Name = request.Name,
                SoTienGiamTru = request.SoTienGiamTru,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow,
            };
            _repository.Add(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
