using BlogService.Dto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService.Validations
{
    public class PostValidation : AbstractValidator<PostDto>
    {
        public PostValidation(DataContext context)
        {

            RuleFor(x => x.Title)
         .NotEmpty()
          .DependentRules(() =>
          {
              RuleFor(x => x.Description)
                            .MinimumLength(5)
                            .DependentRules(() =>
                            {
                                RuleFor(x => x.Title)
                                .Must(x => !context.Posts.Any(y => y.Title == x))
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
                                              .WithMessage("Category is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CategoryId)
                    .Must(x => context.Categories.Any(y => y.Id == x))
                    .WithMessage("Category is not exist");
                });

            RuleFor(x => x.ManufactureId)
               .NotEmpty()
                              .WithMessage("Manufacture is required")
               .DependentRules(() =>
               {
                   RuleFor(x => x.ManufactureId)
                   .Must(x => context.Manufactures.Any(y => y.Id == x))
                   .WithMessage("Manufacture is not exist");
               });

            RuleFor(x => x.SupplierId)
               .NotEmpty()
               .WithMessage("Supplier is required")
               .DependentRules(() =>
               {
                   RuleFor(x => x.SupplierId)
                   .Must(x => context.Suppliers.Any(y => y.Id == x))
                   .WithMessage("Supplier is not exist");
               });
        }
    }
}
