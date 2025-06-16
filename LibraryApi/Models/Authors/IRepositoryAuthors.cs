namespace LibraryApi.Models.Authors;

public interface IAuthorRepository
{
    void Add(Author author);
    void Update(Author author);
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

    public void Update(Author author)
    {
        throw new NotImplementedException();
    }
}