﻿using FluentValidation;

namespace NhaMayThep.Application.DangKiTangCa.GetId
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
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
