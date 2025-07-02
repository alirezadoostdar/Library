using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Migrations
{
    [Migration(202507021019)]
    public class _202507021019_Add_BookLoans : Migration
    {
        public override void Up()
        {
            Create.Table("BookLoans")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("RegisterDate").AsDateTime().NotNullable()
                .WithColumn("MustReturnDate").AsDateTime().NotNullable()
                .WithColumn("ReturnDate").AsDateTime().Nullable()
                .WithColumn("MemberId").AsInt32().NotNullable()
                .WithColumn("BookId").AsInt32().NotNullable();

            Create.ForeignKey("Fk_BookLoans_Members")
                .FromTable("BookLoans")
                .ForeignColumn("MemberId")
                .ToTable("Members")
                .PrimaryColumn("Id");

            Create.ForeignKey("Fk_BookLoans_Book")
                .FromTable("BookLoans")
                .ForeignColumn("BookId")
                .ToTable("Books")
                .PrimaryColumn("Id");

        }

        public override void Down()
        {
            Delete.ForeignKey("Fk_BookLoans_Book");
            Delete.ForeignKey("Fk_BookLoans_Members");
            Delete.Table("BookLoans");
        }

    }
}
