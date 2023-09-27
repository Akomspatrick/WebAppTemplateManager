using DocumentVersionManager.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Validators
{
    public class AddNewModelTypeValidator:AbstractValidator<AddNewModelTypeCommand>
    {
        public AddNewModelTypeValidator()
        {
                RuleFor(x=>x.modelTypeName).NotNull().NotEmpty();
        }
    }
}
