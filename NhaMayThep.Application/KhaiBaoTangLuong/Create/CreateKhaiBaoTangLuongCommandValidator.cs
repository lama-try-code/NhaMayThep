﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    using FluentValidation;
    using NhaMayThep.Application.KhaiBaoTangLuong.Create;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
    {
        public class CreateKhaiBaoTangLuongCommandValidator : AbstractValidator<CreateKhaiBaoTangLuongCommand>
        {
            public CreateKhaiBaoTangLuongCommandValidator()
            {



                RuleFor(x => x.PhanTramTang)
                    .NotNull().WithMessage("PhanTramTang không được để trống.")
                    .GreaterThanOrEqualTo(0).WithMessage("PhanTramTang phải lớn 0");

                RuleFor(x => x.NgayApDung)
                    .NotNull().WithMessage("NgayApDung không được để trống.");

                RuleFor(x => x.LyDo)
                    .NotNull().WithMessage("LyDo không được để trống.");
            }
        }
    }
}
