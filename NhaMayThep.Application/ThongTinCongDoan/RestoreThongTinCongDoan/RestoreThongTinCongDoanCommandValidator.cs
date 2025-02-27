﻿using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommandValidator : AbstractValidator<RestoreThongTinCongDoanCommand>
    {
        public RestoreThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
                .NotNull().WithMessage("Mã thông tin công đoàn không được rỗng");
        }
    }
}
