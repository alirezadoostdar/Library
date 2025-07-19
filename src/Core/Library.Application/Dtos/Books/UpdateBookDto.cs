namespace Library.Application.Dtos.Books;

public record UpdateBookDto
(
    int Id,
    string Title,
    string Description,
    int CategoryId
);
