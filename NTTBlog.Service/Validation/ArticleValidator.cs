using FluentValidation;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Validation
{
    public class ArticleValidator : AbstractValidator<ArticleAddVM>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MinimumLength(5).MaximumLength(250);

           

        }
    }
}
