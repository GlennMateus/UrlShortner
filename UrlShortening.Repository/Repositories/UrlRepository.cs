

using Domain.Models;
using Domain.Models.Errors;
using Infrastructure.Data.SQL;
using Infrastructure.Interfaces;
using UrlShortening.Domain.Models.CreateUrlModelRequest;
using UrlShortening.Domain.Models.CreateUrlModelResponse;
using UrlShortening.Domain.Validators.CreateUrlRequestValidator;

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
        var validator = new CreateUrlRequestValidator();
        var validationResultesult = validator.Validate(data);
        if (!validationResultesult.IsValid)
        {
            throw new ArgumentException(
                string.Join("\n- ", validationResultesult.Errors)
            );
        }
        if(GetBySlug(data.Slug) != null)
        {
            throw new SlugAlreadyExistsException($"Slug: {data.Slug} already in use!");
        }
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
}