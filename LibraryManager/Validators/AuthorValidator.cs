using FluentValidation;
using LibraryManager.Models;

namespace LibraryManager.Validators;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(a => a.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required")
            .InclusiveBetween(new DateTime(1200, 1, 1), DateTime.Today)
            .WithMessage("Дата рождения должна быть между 1200 и сегодняшним днем");
    }
}