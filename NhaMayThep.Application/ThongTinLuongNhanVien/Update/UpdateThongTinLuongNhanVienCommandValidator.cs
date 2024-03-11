﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandValidator : AbstractValidator<UpdateThongTinLuongNhanVienCommand>
    {
        public UpdateThongTinLuongNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is Required");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.MaSoHopDong)
                .NotEmpty().WithMessage("Ma So Hop Dong is Required");

            RuleFor(x => x.Loai)
                .NotEmpty().WithMessage("Loai is Required")
                .Must(x => x == "TangLuong" || x == "GiamLuong")
                .WithMessage("Invalid value for Loai. It should be either TangLuong or GiamLuong"); ;

            RuleFor(x => x.LuongCu)
                .NotEmpty().WithMessage("Luong Cu is Required")
                .GreaterThan(0).WithMessage("Luong Cu must be greater than 0");

            RuleFor(x => x.LuongMoi)
                .NotEmpty().WithMessage("Luong Hien Tai is Required")
                .GreaterThan(0).WithMessage("Luong Hien Tai must be greater than 0");

            RuleFor(x => x.NgayHieuLuc)
                .NotEmpty().WithMessage("Ngay Hien Luc is Required");

        }
    }
}
