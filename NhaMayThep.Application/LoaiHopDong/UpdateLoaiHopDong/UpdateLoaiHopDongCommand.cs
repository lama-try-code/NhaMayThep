﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommand : IRequest<LoaiHopDongDto>, ICommand
    {
        public UpdateLoaiHopDongCommand(int id, string tenHopDong)
        {
            Id = id;
            TenHopDong = tenHopDong;
        }

        public int Id { get; set; }
        public string TenHopDong {  get; set; }
    }
}
