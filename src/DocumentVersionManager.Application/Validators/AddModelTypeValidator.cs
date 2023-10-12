using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Validators
{
    public class AddModelTypeValidator : AbstractValidator<AddNewModelTypeCommand>
    {
        public AddModelTypeValidator()
        {
            RuleFor(x => x.modelTypeName).NotNull().NotEmpty();
            // RuleFor(x=>x.modelTypeName)..NotEmpty();
        }
    }
}
