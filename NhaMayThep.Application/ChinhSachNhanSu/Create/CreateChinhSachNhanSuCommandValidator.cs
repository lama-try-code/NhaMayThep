﻿using FluentValidation;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommandValidator : AbstractValidator<CreateChinhSachNhanSuCommand>
    {
        public CreateChinhSachNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name không được trống");

            RuleFor(v => v.MucDo)
                .NotEmpty().WithMessage("MucDo không được trống");

            RuleFor(v => v.NgayHieuLuc)
                .NotNull().WithMessage("NgayHieuLuc không được trống");

        }
    }
}
