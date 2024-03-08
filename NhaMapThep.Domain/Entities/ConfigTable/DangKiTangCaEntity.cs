﻿using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("DangKiTangCa")]
    public class DangKiTangCaEntity : Entity
    {
        [Required]
        public int MaTangCa { get; set; }


        [Required]
        [ForeignKey(nameof(NhanVien))]
        public string MaSoNhanVien { get; set; }
        public virtual NhanVienEntity NhanVien { get; set; }

        [Required]
        public DateTime NgayLamTangCa { get; set; }
        [Required]
        [ForeignKey(nameof(MaDangKiCaLam))]
        public int CaDangKi { get; set; }
        public virtual MaDangKiCaLamEntity MaDangKiCaLam { get; set; }

        [Required]
        public string LiDoTangCa { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }

        public DateTime ThoiGianCaLamKetThuc { get; set; }

        [Required]
        public TimeSpan SoGioTangCa { get; set; }

        [Required]
        public decimal HeSoLuongTangCa { get; set; }
        [Required]
        public int TrangThaiDuyet { get; set; }


         public required string NguoiDuyet { get; set; }
        [ForeignKey(nameof(NguoiDuyet))]
        public virtual NhanVienEntity NguoiDuyetNhanVien { get; set; }

    }


}
