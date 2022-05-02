
using Domain.Models;
using UrlShortening.Domain.Models.CreateUrlModelRequest;
using UrlShortening.Domain.Models.CreateUrlModelResponse;

namespace Infrastructure.Interfaces;

public interface IUrlRepository
{
    UrlModel GetBySlug(string slug);
    CreateUrlModelResponse Add(CreateUrlModelRequest data);
}