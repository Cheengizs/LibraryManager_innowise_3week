using FluentValidation;
using LibraryManager.Models;

namespace LibraryManager.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required")
            .Length(2, 100).WithMessage("Title must be between 2 and 100 characters");
        
        RuleFor(b => b.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(b => b.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required")
            .GreaterThan(0).WithMessage("AuthorId must be greater than 0");
        
        RuleFor(b => b.PublishedYear)
            .NotEmpty().WithMessage("PublishedYear is required")
            .GreaterThan(1200).WithMessage("PublishedYear must be greater than 1200");
    }
}