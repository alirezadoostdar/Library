using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Migrations
{
    [Migration(202506032316)]
    public class _202506032316_Add_Category_Table : Migration
    {

        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("AgeGroupId").AsInt16().NotNullable();

            Create.ForeignKey("Fk_Categories_AgeGroups")
                .FromTable("Categories")
                .ForeignColumn("AgeGroupId")
                .ToTable("AgeGroups")
                .PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("Fk_Categories_AgeGroups");
            Delete.Table("Categories");
        }

    }
}
