using FluentMigrator;

namespace LibraryApi.Migrations;

public class _202506052110_Add_book : Migration
{
    public override void Up()
    {
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(200).NotNullable()
            .
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}