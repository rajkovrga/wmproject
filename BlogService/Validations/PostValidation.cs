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
                    RuleFor(x => x.Title)
                    .Must(x => !context.Posts.Any(y => y.Title == x))
                    .WithMessage("This title exist");
                });

            RuleFor(x => x.Description)
              .NotEmpty();

            RuleFor(x => x.Category)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Category)
                    .Must(x => !context.Posts.Any(y => y.Category.Id == x.Id))
                    .WithMessage("Category is not good");
                });

            RuleFor(x => x.Manufacture)
               .NotEmpty()
               .DependentRules(() =>
               {
                   RuleFor(x => x.Manufacture)
                   .Must(x => !context.Posts.Any(y => y.Manufacture.Id == x.Id))
                   .WithMessage("Category is not good");
               });

            RuleFor(x => x.Supplier)
               .NotEmpty()
               .DependentRules(() =>
               {
                   RuleFor(x => x.Supplier)
                   .Must(x => !context.Posts.Any(y => y.Supplier.Id == x.Id))
                   .WithMessage("Category is not good");
               });
        }
    }
}
