﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class CanCuocCongDanRepository : RepositoryBase<CanCuocCongDanEntity, CanCuocCongDanEntity, ApplicationDbContext>, ICanCuocCongDanRepository
    {
        public CanCuocCongDanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<CanCuocCongDanEntity?> FindById(string cccd, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CanCuocCongDan.Equals(cccd), cancellationToken);
        }
    }
}
