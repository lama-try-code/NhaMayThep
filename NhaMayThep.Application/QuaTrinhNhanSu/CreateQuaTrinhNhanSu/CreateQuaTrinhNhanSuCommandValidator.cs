﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommandValidator : AbstractValidator<CreateQuaTrinhNhanSuCommand>
    {
        public CreateQuaTrinhNhanSuCommandValidator()
        {

            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {

        }
    }
}
