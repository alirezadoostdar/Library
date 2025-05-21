using FluentValidation;

namespace LibraryApi.Models.Books;

public class UpdateBookRateDto
{
    public int Rate { get; set; }
}

public class UpdateBookRateDtoValidator : AbstractValidator<UpdateBookRateDto>
{
    public UpdateBookRateDtoValidator()
    {
        RuleFor(x => x.Rate)
            .InclusiveBetween(1, 5)
            .WithMessage("Rating must be between 1 and 5.");
    }
}
