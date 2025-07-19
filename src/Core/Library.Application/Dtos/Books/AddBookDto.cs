namespace Library.Application.Dtos.Books;

public record AddBookDto
(
    string Title,
    string Description,
    int CategoryId
);
