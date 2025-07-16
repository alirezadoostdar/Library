using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Library.Infarstructure;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("LibraryConnectionString");
    }

}
