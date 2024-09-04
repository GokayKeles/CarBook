﻿using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidator
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz!");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız!");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter veri girişi yapınız!");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görselini boş geçmeyiniz!").MinimumLength(10).WithMessage("Lütfen en az 10 karakter uzunluğunda veri girişi yapınız.").MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter uzunluğunda veri girişi yapınız.");
        } 
    }
}
