using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System.Data;
using Dapper;

namespace Library.Infarstructure.Repositories.Categories;

public class DapperCategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _connection;

    public DapperCategoryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<Category> AddAsync(Category category)
    {
        string command = @"Insert into Categories Values(@Tilte)
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
        var parameters = new DynamicParameters();
        parameters.Add("Title", category.Title, DbType.String);

        category.Id = await _connection.ExecuteScalarAsync<int>(command, parameters, commandType: CommandType.Text);
        return category;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
