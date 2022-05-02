using FluentValidation;
using UrlShortening.Domain.Models.CreateUrlModelRequest;

namespace UrlShortening.Domain.Validators.CreateUrlRequestValidator;

public class CreateUrlRequestValidator : AbstractValidator<CreateUrlModelRequest> 
{
    public CreateUrlRequestValidator()
    {
        RuleFor(url => url.Url)
            .NotEmpty()
            .WithMessage("Parameter {PropertyName} cannot be empty!");
        RuleFor(url => url.Slug);
    }
}