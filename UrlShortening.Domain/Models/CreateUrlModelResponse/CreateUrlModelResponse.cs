
namespace UrlShortening.Domain.Models.CreateUrlModelResponse;

public class CreateUrlModelResponse
{

    public CreateUrlModelResponse(Guid id, string url, string slug, DateTime createDate)
    {
        Id = id;
        Url = url;
        Slug = slug;
        CreateDate = createDate;
    }

    public Guid Id { get; private set; }
    public string Url { get; private set; }
    public string Slug { get; private set; }
    public DateTime CreateDate { get; private set; }
}
