using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Migrations
{
    [Migration(202506032258)]
    public class _202506032258_Initial_Migrations : Migration
    {
        public override void Up()
        {
            Create.Table("AgeGroups")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Title").AsString(50).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("AgeGroups");
        }


    }
}
