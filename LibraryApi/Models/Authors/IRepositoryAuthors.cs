namespace LibraryApi.Models.Authors;

public interface IAuthorRepository
{
    void Add(Author author);
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
        throw new NotImplementedException();
    }
}