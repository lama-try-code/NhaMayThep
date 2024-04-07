﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.GetId
{
    public class GetByIdQueryValidator : AbstractValidator<GetDangKiTangCaByIdQuery>
    {
        public GetByIdQueryValidator()
        {

            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("ID không để trống")
                .NotNull().WithMessage("ID không được rỗng");
        }

    }
}
