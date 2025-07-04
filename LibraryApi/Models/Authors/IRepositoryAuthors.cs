using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.Authors;

public interface IAuthorRepository
{
    void Add(Author author);
    void Update(Author author);
    void Delete(int id);
    Author? FindById(int id);
    List<GetAuthorDto> GetAll();

}


public class AuthorRepository : IAuthorRepository
{
    public readonly ApplicationDbContext Context;

    public AuthorRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public void Add(Author author)
    {
        Context.Authors.Add(author);
        Context.SaveChanges();
    }

    public void Delete(int id)
    {
        Context.Authors.Remove(FindById(id));
        Context.SaveChanges();
    }

    public Author? FindById(int id)
    {
        return Context.Authors
            .Include(x => x.Books).FirstOrDefault(x => x.Id == id);
    }

    public List<GetAuthorDto> GetAll()
    {
        return Context.Authors.Select(x => new GetAuthorDto
        {
            Id = x.Id,
            Name = x.Name,
            Family=x.Family,
            Address = x.ContactInfo.Address,
            PhoneNumber = x.ContactInfo.PhoneNumber,
            LicenseNumber = x.LicenseNumber,
            Birthday = x.Birthday,
        }).ToList();
    }

    public void Update(Author author)
    {
        Context.SaveChanges();
    }
}