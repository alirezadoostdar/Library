using FluentMigrator;

namespace LibraryApi.Migrations;

[Migration(202507061442)]
public class _202507061442_Add_Invoice : Migration
{
    public override void Up()
    {
        Create.Table("Invoices")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Date").AsDate().NotNullable()
            .WithColumn("MemberId").AsInt32().NotNullable()
            .WithColumn("Sign").AsInt16().NotNullable()
            .WithColumn("Type").AsInt16().NotNullable();

        Create.Table("InvoiceTypes")
            .WithColumn("Id").AsInt16().PrimaryKey()
            .WithColumn("Title").AsString(20).NotNullable();

        Insert.IntoTable("InvoiceTypes").Row(new { Id = 1, Title = "Sales" });
        Insert.IntoTable("InvoiceTypes").Row(new { Id = 2, Title = "Purchase" });
        Insert.IntoTable("InvoiceTypes").Row(new { Id = 3, Title = "Sales Return" });
        Insert.IntoTable("InvoiceTypes").Row(new { Id = 4, Title = "Purchase Return" });

        Create.Table("InvoiceDetails")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("InvoiceId").AsInt32().NotNullable()
            .WithColumn("BookId").AsInt32().NotNullable()
            .WithColumn("Quantity").AsDecimal().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();

        Create.ForeignKey("Fk_Invoice_Type")
            .FromTable("Invoices")
            .ForeignColumn("Type")
            .ToTable("InvoiceTypes")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_Invoice_Member")
            .FromTable("Invoices")
            .ForeignColumn("MemberId")
            .ToTable("Members")
            .PrimaryColumn("Id");

        Create.ForeignKey("Fk_InvoiceDetail_BooK")
            .FromTable("InvoiceDetails")
            .ForeignColumn("InvoiceId")
            .ToTable("Invoices")
            .PrimaryColumn("Id");


        Create.ForeignKey("Fk_InvoiceDetail_Invoice")
            .FromTable("InvoiceDetails")
            .ForeignColumn("BookId")
            .ToTable("Books")
            .PrimaryColumn("Id")
            .OnDelete(System.Data.Rule.Cascade);
    }
    public override void Down()
    {
        Delete.ForeignKey("Fk_InvoiceDetail_Invoice");
        //Delete.ForeignKey("Fk_InvoiceDetail_BooK");
        //Delete.ForeignKey("Fk_Invoice_Member");
        //Delete.ForeignKey("Fk_Invoice_Type");

        //Delete.Table("InvoiceDetails");
        //Delete.Table("InvoiceTypes");
        //Delete.Table("Invoices");
    }

}
