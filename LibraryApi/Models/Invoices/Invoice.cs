using LibraryApi.Models.Books;
using LibraryApi.Models.Members;

namespace LibraryApi.Models.Invoices;

public class Invoice
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public int Sign { get; set; }
    public InvoiceType Type { get; set; }
    public ICollection<InvoiceItems> Items { get; set; } = new List<InvoiceItems>();
}

public class InvoiceItems
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }

    public decimal Quantity { get; set; }
    public decimal Price { get; set; }

    public Invoice Invoice { get; set; } = null;
}

public enum InvoiceType
{
    Sales = 1,
    Purchase = 2,
    SalesReturn = 3,
    PurchaseReturn = 4
}

