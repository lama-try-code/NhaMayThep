﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien
{
    public class CreateThongTinDangVienCommand : IRequest<string>, ICommand
    {
        public CreateThongTinDangVienCommand(string id, string nhanVienId, DateTime ngayVaoDang, string capDangVien )
        {
            ID = id;
            NhanVienID = nhanVienId;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }

        public string ID { get; set; }
        public string NhanVienID { get; set; }

        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }


    }
}
