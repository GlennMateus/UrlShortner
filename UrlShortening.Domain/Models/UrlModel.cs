using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class UrlModel
{
    public UrlModel()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.Now;
        Slug = Nanoid.Nanoid.Generate(size: 10);
    }

    public UrlModel(string url, string slug = "") : this()
    {
        Url = url;
        if (!string.IsNullOrWhiteSpace(slug)) Slug = slug;
    }

    public Guid Id { get; private set; }
    public string Url { get; private set; }
    public string Slug { get; private set; }
    
    public DateTime CreationDate { get; private set; }
}