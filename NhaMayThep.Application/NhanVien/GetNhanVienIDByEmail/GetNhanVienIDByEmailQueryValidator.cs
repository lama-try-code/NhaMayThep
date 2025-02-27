﻿using FluentValidation;

namespace NhaMayThep.Application.NhanVien.GetNhanVienIDByEmail
{
    public class GetNhanVienIDByEmailQueryValidator : AbstractValidator<GetNhanVienIDByEmailQuery>
    {
        public GetNhanVienIDByEmailQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email không để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");
        }
    }
}
