namespace LibraryApi.Models.Categories;

public interface ICategoryRepository
{
    void Add(Category category);
    List<GetCategoryDto> GetAll();
    GetCategoryDto GetById(int id);
    void Update(Category category);
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

    public GetCategoryDto? GetById(int id)
    {
        return _context.Categories.Where(x => x.Id == id)
            .Select(x => new GetCategoryDto
            {
                Id = x.Id,
                Title = x.Title,
            }).FirstOrDefault();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }
}
