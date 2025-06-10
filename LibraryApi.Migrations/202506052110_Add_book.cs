using FluentMigrator;

namespace LibraryApi.Migrations;

public class _202506052110_Add_book : Migration
{
    public override void Up()
    {
        Create.Table("ContactInfos")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Address").AsString(200).Nullable()
            .WithColumn("PhoneNumber").AsString(20).NotNullable();

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
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}