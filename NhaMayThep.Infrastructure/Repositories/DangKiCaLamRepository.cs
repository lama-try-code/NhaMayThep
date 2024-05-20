﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class DangKiCaLamRepository : RepositoryBase<DangKiCaLamEntity, DangKiCaLamEntity, ApplicationDbContext>, IDangKiCaLamRepository
    {
        public DangKiCaLamRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
