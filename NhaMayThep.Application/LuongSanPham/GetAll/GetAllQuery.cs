﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllQuery : IRequest<List<LuongSanPhamDto>>, IQuery
    {

    }
}
