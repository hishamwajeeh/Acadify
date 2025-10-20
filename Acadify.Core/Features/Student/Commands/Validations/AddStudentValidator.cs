using Acadify.Core.Features.Student.Commands.Models;
using Acadify.Service.Abstracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Core.Features.Student.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {

        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }


        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x=> x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    var exists = await _studentService.IsNameExist(name);
                    return !exists;
                })
                .WithMessage("A student with the same name already exists.");
        }
    }
}
