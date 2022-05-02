using Infrastructure.Interfaces;
using UrlShortening.Domain.Models.CreateUrlModelRequest;

namespace Public.PostUrl;

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
        Post("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var url = _repository.Add(new CreateUrlModelRequest(req.Url, req.Slug));
        await SendAsync(url);
    }
}