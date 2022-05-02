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
}