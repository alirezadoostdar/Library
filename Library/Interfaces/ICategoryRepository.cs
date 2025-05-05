using Library.Models;

namespace Library.Interfaces;

public interface ICategoryRepository
{
    void Add(Category category);
    void Update(Category category);
    void Delete(int id);
    Category GetById(int id);
    IEnumerable<Category> GetAll();
}
