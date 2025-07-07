using LibraryApi.Models;
using LibraryApi.Models.Authors;
using LibraryApi.Models.BookLoans;
using LibraryApi.Models.Books;
using LibraryApi.Models.Categories;
using LibraryApi.Models.Invoices;
using LibraryApi.Models.Members;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnectionString"));
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  
builder.Services.AddScoped<IBookRepository, BookRepository>();  
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();  
builder.Services.AddScoped<IMemberRepository, MemberRepository>();  
builder.Services.AddScoped<IBookLoansRepository, BookLoansRepository>();  
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
