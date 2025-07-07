using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.Invoices;

public interface IInvoiceRepository
{
    void Add(Invoice invoice);
    void Update(Invoice invoice);
    void Delete(int id);
    Invoice? GetById(int id);

}

public class InvoiceRepository : IInvoiceRepository
{
    public readonly ApplicationDbContext _context;

    public InvoiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Invoice? GetById(int id)
    {
        return _context.Invoices
            .Include(x => x.Items)
            .FirstOrDefault(x => x.Id == id);   
    }

    public void Update(Invoice invoice)
    {
        throw new NotImplementedException();
    }
}
