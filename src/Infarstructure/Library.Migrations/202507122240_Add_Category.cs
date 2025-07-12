using FluentMigrator;

namespace Library.Migrations;

[Migration(202507122240)]
public class _202507122240_Add_Category : Migration
{

    public override void Up()
    {
        Create.Table("Categories")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(50).NotNullable();
    }
    public override void Down()
    {
        Delete.Table("Categories");
    }
}
