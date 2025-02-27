﻿using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("KhenThuong")]
    public class KhenThuongEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public required int ChinhSachNhanSuID { get; set; }
        [ForeignKey(nameof(ChinhSachNhanSuID))]
        public virtual ChinhSachNhanSuEntity ChinhSachNhanSu { get; set; }
        public string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TongThuong { get; set; }
    }
}
