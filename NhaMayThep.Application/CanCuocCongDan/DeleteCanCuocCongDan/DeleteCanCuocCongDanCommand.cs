﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan
{
    public class DeleteCanCuocCongDanCommand : IRequest<string>, ICommand
    {
        public DeleteCanCuocCongDanCommand()
        {
            
        }
        public DeleteCanCuocCongDanCommand(string canCuocCongDan)
        {
            CanCuocCongDan = canCuocCongDan;
        }

        public string CanCuocCongDan { get; set; }
    }

}

