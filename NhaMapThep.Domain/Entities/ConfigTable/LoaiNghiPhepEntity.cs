﻿using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("LoaiNghiPhep")]
    public class LoaiNghiPhepEntity : BangMaGocEntity
    {
        public int SoGioNghiPhep { get; set; }
    }
}
