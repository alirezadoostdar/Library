using FluentValidation;

namespace LibraryApi.Models.Books;

public class AddBookValidator : AbstractValidator<AddBookDto>
{
    public AddBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required");

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Author is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description's length can not be more than 500 characters");
    }
}
