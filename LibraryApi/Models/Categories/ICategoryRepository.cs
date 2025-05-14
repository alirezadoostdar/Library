namespace LibraryApi.Models.Categories;

public interface ICategoryRepository
{
    void Add(Category category);
    List<GetCategoryDto> GetAll();
}


public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public List<GetCategoryDto> GetAll()
    {
       return _context.Categories.Select(x => new GetCategoryDto
       {
           Id = x.Id,
           Title = x.Title,
       }).ToList();
    }
}
