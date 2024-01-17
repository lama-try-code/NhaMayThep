﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepCommand : IRequest<LoaiNghiPhepDto>, ICommand
    {
        public int Id { get; set; }
        public string NguoiXoaID { get; set; }
        public DeleteLoaiNghiPhepCommand(int id, string nguoiXoaID)
        {
            Id = id;
            NguoiXoaID = nguoiXoaID;
        }
    }
}