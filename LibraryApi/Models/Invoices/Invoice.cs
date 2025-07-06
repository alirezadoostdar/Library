using LibraryApi.Models.Books;
using LibraryApi.Models.Members;

namespace LibraryApi.Models.Invoices;

public class Invoice
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public byte Sign { get; set; }
    public InvoiceType Type { get; set; }
    public HashSet<InvoiceDetil> Items { get; set; }
}

public class InvoiceDetil
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }

    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}

public enum InvoiceType
{
    Sell = 1,
    Buy = 2,
    SellReturn = 3,
    BuyReturn = 4
}

