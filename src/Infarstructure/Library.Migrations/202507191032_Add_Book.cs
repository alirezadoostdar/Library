using FluentMigrator;

namespace Library.Migrations;

[Migration(202507191032)]
public class _202507191032_Add_Book : Migration
{
    public override void Up()
    {
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(50).NotNullable()
            .WithColumn("Description").AsString(200).Nullable()
            .WithColumn("CategoryId").AsInt32().NotNullable();

        Create.ForeignKey("Fk_Books_Category")
            .FromTable("Books")
            .ForeignColumn("CategoryId")
            .ToTable("Categories")
            .PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.Table("Books");
        Delete.ForeignKey("Fk_Books_Category");
    }

}
