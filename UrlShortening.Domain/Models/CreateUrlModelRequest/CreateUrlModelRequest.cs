using UrlShortening.Domain.Validators.CreateUrlRequestValidator;

namespace UrlShortening.Domain.Models.CreateUrlModelRequest;

public class CreateUrlModelRequest
{
    public CreateUrlModelRequest(string url, string slug)
    {
        Url = url;
        Slug = slug;
    }

    public string Url { get; }
    public string Slug { get; }

    public void Validate()
    {
        var validator = new CreateUrlRequestValidator();
        var validationResultesult = validator.Validate(this);
        if (!validationResultesult.IsValid)
        {
            throw new ArgumentException(
                string.Join("\n- ", validationResultesult.Errors)
            );
        }
    }
}