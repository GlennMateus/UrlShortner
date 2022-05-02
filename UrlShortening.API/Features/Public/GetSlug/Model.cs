namespace Public.GetSlug;

public class Request
{
    [QueryParam] [BindFrom("slug")] public string Slug { get; set; }
}

public class ErrorResponse
{
    public ErrorResponse(string message)
    {
        Message = message;
    }

    public string Message { get; }
}

public class Response
{
    public Response(string url, string slug)
    {
        Url = url;
        Slug = slug;
    }

    public string Url { get; }
    public string Slug { get; }
}