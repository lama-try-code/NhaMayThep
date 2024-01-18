﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

public class LoaiNghiPhepRepository : RepositoryBase<LoaiNghiPhepEntity, LoaiNghiPhepEntity, ApplicationDbContext>, ILoaiNghiPhepRepository
{
    public LoaiNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

 
}
