﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.Update
{
    public class UpdateMucSanPhamCommand : IRequest<string>, ICommand
    {
        public UpdateMucSanPhamCommand(string id, int mucSanPhamToiThieu, int mucSanPhamToiDa, decimal luongMucSanPham)
        {
            ID = id;
            MucSanPhamToiThieu = mucSanPhamToiThieu;
            MucSanPhamToiDa = mucSanPhamToiDa;
            LuongMucSanPham = luongMucSanPham;
        }
        public string ID { get; set; }
        public int MucSanPhamToiThieu { get; set; }
        public int MucSanPhamToiDa { get; set; }
        public decimal LuongMucSanPham { get; set; }
    }
}
