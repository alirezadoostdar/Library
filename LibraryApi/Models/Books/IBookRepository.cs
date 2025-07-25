﻿using LibraryApi.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.Books;

public interface IBookRepository
{
    void Delete(Book book);    
    void Add(Book book);
    List<GetBookDto> GetAll();
    void Update(Book book);
    Book? GetById(int id);
    GetBookDto? GetByCode(string code);
    List<GetBookByRateDto> GetListByRate();
}

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<GetBookDto> GetAll()
    {
        return _context.Books.Select(x => new GetBookDto
        {
            Tilte = x.Title,
            Code = x.Code,
            Category = x.Category.Title,
            AgeGroup = x.Category.AgeGroup.Title
        }).ToList();
    }

    public GetBookDto? GetByCode(string code)
    {
        return _context.Books.Where(x => x.Code == code)
            .Select(x => new GetBookDto
            {
                Id = x.Id,
                Tilte = x.Title,
                AgeGroup = x.Category.AgeGroup.Title,
                Code = x.Code,
                Category = x.Category.Title
            }).FirstOrDefault();
    }

    public Book? GetById(int id)
    {
        return _context.Books
            .Include(x => x.Category)
            .Include(x => x.Category.AgeGroup)
            .FirstOrDefault(x => x.Id == id);
    }

    public List<GetBookByRateDto> GetListByRate()
    {
        return _context.Books.Select(x => new GetBookByRateDto
        {
            Tilte = x.Title,
            Code = x.Code,
            Category = x.Category.Title,
            AgeGroup = x.Category.AgeGroup.Title,
            Rate = x.Rates.Any() ? x.Rates.Average(x => x.Value) : 0,
        }).ToList();
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }
}
