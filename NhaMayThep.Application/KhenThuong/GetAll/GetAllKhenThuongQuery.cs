﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetAll
{
    public class GetAllKhenThuongQuery : IRequest<List<KhenThuongDto>>, IQuery
    {
        public GetAllKhenThuongQuery() { }
    }
}
