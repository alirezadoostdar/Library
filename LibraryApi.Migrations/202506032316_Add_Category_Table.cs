using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Migrations
{
    [Migration(202506032316)]
    internal class _202506032316_Add_Category_Table : Migration
    {

        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("AgeGroupId").AsInt16().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Categories");
        }

    }
}
