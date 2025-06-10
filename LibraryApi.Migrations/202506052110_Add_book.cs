using FluentMigrator;
using FluentMigrator.Expressions;

namespace LibraryApi.Migrations;

public class _202506052110_Add_book : Migration
{
    public override void Up()
    {

        Create.Table("BookRates")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Value").AsInt16().NotNullable()
            .WithColumn("BookId").AsInt32().NotNullable();

        Create.Table("Authors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Family").AsString(50).NotNullable()
            .WithColumn("PhoneNumber").AsString(20).NotNullable()
            .WithColumn("Address").AsString(200)
            .WithColumn("LicenseNumber").AsInt32().NotNullable()
            .WithColumn("Birthday").AsDateTime().NotNullable();

        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("AuthorId").AsInt32().NotNullable()
            .WithColumn("Description").AsString(200)
            .WithColumn("Code").AsString(20).NotNullable()
            .WithColumn("PublishDate").AsDateTime().NotNullable()
            .WithColumn("Pages").AsInt32().NotNullable()
            .WithColumn("CategoryId").AsInt32();

        Create.ForeignKey("Fk_Books_Authors")
            .FromTable("Books")
            .ForeignColumns("AuthorId")
            .ToTable("Authors")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Books_Categories")
            .FromTable("Books")
            .ForeignColumn("CategoryId")
            .ToTable("CategoryId")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Books_Rates")
            .FromTable("BookRates")
            .ForeignColumns("BookId")
            .ToTable("Books")
            .PrimaryColumn("Id");

    }

    public override void Down()
    {
        Delete.ForeignKey("Fk_Books_Rates");
        Delete.Table("Books_Rates");
        Delete.ForeignKey("Fk_Books_Categories");
        Delete.ForeignKey("Fk_Books_Authors");
        Delete.Table("Books");
        Delete.Table("Authors");
        Delete.Table("BookRates");
    }
}