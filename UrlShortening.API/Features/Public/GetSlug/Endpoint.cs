using Infrastructure.Interfaces;

namespace Public.GetSlug;

public class UrlEndpoint : Endpoint<Request>
{
    private readonly IUrlRepository _repository;
    private ILogger _logger;

    public UrlEndpoint(IUrlRepository repository, ILogger<UrlEndpoint> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var url = _repository.GetBySlug(req.Slug);
        if (url is null)
            await SendAsync(new ErrorResponse("Slug not found"));
        else
            await SendAsync(new Response(url.Url, url.Slug));
    }
}