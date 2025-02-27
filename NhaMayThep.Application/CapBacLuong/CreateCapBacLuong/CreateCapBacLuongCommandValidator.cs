﻿using FluentValidation;

namespace NhaMayThep.Application.CapBacLuong.CreateCapBacLuong
{
    public class CreateCapBacLuongCommandValidator : AbstractValidator<CreateCapBacLuongCommand>
    {
        public CreateCapBacLuongCommandValidator()
        {
            RuleFor(x => x.TenCapBac)
                .NotEmpty().WithMessage("Tên cấp bậc không được để trống.")
                .NotNull().WithMessage("Tên cấp bậc không được để rỗng.");
            RuleFor(x => x.HeSoLuong)
                .NotEmpty().WithMessage("Hệ số lương không được để trống.")
                .NotNull().WithMessage("Hệ số lương không được để rỗng."); ;
        }
    }
}
