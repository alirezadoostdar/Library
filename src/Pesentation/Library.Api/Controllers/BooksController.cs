﻿using Library.Application.Dtos.Books;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


[ApiController]
[Route("api/books")]
public class BooksController : Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(AddBookDto dto)
    {
        var result = await _bookService.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var bookDto = await _bookService.GetByIdAsync(id);
        return Ok(bookDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var list = await _bookService.GetAllAsync();
        return Ok(list);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _bookService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync(int id, UpdateBookDto dto)
    {
         await _bookService.UpdateAsync(id, dto);
        return Ok();
    }

}
