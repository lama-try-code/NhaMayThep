﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class MaDangKiCaLamConfiguration : IEntityTypeConfiguration<MaDangKiCaLamEntity>
    {
        public void Configure(EntityTypeBuilder<MaDangKiCaLamEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaDangKi");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenMaDangKi");
        }
    }
}
