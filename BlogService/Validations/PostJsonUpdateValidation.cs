using BlogService.Dto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService.Validations
{
    public class PostJsonUpdateValidation : AbstractValidator<PostDto>
    {
        public PostJsonUpdateValidation(JsonContext context)
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(5)
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.Description)
                                   .MinimumLength(5)
                                   .DependentRules(() =>
                                   {
                                       RuleFor(x => x)
                                       .Must(x => !context.Posts.Any(y => y.Title == x.Title && y.Id != x.Id))
                                       .WithMessage("This title exist");
                                   });

                 });


            RuleFor(x => x.Description)
              .NotEmpty()
              .DependentRules(() =>
              {
                  RuleFor(x => x.Description)
                                .MinimumLength(5);

              });

            RuleFor(x => x.Price)
                .NotEmpty()
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.Price)
                        .GreaterThanOrEqualTo(0);

                 });

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(x => x)
                    .Must(x => context.Categories.Any(y => y.Id == x.CategoryId))
                    .WithMessage("Category is not good");
                });

            RuleFor(x => x.ManufactureId)
               .NotEmpty()
               .DependentRules(() =>
               {
                   RuleFor(x => x)
                   .Must(x => context.Manufactures.Any(y => y.Id == x.ManufactureId))
                   .WithMessage("Manufacture is not good");
               });

            RuleFor(x => x.SupplierId)
               .NotEmpty()
               .DependentRules(() =>
               {
                   RuleFor(x => x)
                   .Must(x => context.Suppliers.Any(y => y.Id == x.SupplierId))
                   .WithMessage("Supplier is not good");
               });
        }
    }
}
