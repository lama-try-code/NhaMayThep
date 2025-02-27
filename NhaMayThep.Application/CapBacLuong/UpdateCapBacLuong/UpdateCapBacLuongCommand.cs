﻿using MediatR;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenCapBac { get; set; }
        public float HeSoLuong { get; set; }
        public string TrinhDo { get; set; }
        public UpdateCapBacLuongCommand(int id, string tenCapBac, float heSoLuong, string trinhDo)
        {
            Id = id;
            TenCapBac = tenCapBac;
            HeSoLuong = heSoLuong;
            TrinhDo = trinhDo;
        }
    }
}
