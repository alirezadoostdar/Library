using Library.Application.Dtos.Categories;

namespace Library.Application.Dtos.Books;

public record GetBookDto
(
    int Id,
    string Title,
    string Description,
    GetCategoryDto Category
);
