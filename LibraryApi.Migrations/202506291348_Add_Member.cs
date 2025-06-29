using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Migrations
{
    [Migration(202506291348)]
    public class _202506291348_Add_Member : Migration
    {
        public override void Up()
        {
            Create.Table("Members")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Family").AsString(50).NotNullable()
                .WithColumn("MembershipNumber").AsInt32().NotNullable()
                .WithColumn("MemberShipDate").AsDateTime().NotNullable()
                .WithColumn("Address").AsString(200).Nullable()
                .WithColumn("PhoneNumber").AsString(11).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Members");
        }

    }
}
