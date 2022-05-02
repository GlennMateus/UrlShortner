namespace Public.PostUrl;

public class Request
{
    public string Slug { get; set; }
    public string Url { get; set; }
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
    public Response(Guid id, string url, string slug)
    {
        Id = id;
        Url = url;
        Slug = slug;
    }

    public Guid Id { get; }
    public string Url { get; }
    public string Slug { get; }
}