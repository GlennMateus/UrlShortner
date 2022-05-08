using Domain.Models;
using Domain.Models.Errors;
using Infrastructure.Data.SQL;
using Infrastructure.Interfaces;
using UrlShortening.Domain.Models.CreateUrlModelRequest;
using UrlShortening.Domain.Models.CreateUrlModelResponse;

namespace Infrastructure.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly UrlContext _dbContext;

    public UrlRepository(UrlContext context)
    {
        _dbContext = context;
    }

    public CreateUrlModelResponse Add(CreateUrlModelRequest data)
    {
        data.Validate();
        CheckIfSlugExists(data.Slug);
        var newUrl = _dbContext.Url.Add(new UrlModel(data.Url, data.Slug));
        _dbContext.SaveChanges();

        return new CreateUrlModelResponse(
            newUrl.Entity.Id,
            newUrl.Entity.Url,
            newUrl.Entity.Slug,
            newUrl.Entity.CreationDate
        );
    }

    public UrlModel GetBySlug(string slug)
    {
        var url = _dbContext.Url.FirstOrDefault(url => url.Slug.Equals(slug));
        return url;
    }

    private void CheckIfSlugExists(string slug)
    {
        var testSlug = GetBySlug(slug);
        if(testSlug != null)
        {
            throw new SlugAlreadyExistsException($"Slug: {slug} already in use!");
        }
    }
}