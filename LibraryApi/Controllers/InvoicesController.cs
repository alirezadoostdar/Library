using LibraryApi.Models.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/invoices")]
public class InvoicesController : Controller
{
    public readonly IInvoiceRepository _invoiceRepository;

    public InvoicesController(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    [HttpGet("{id:int}")]
    public Invoice GeyById(int id)
    {
        return _invoiceRepository.GetById(id);
    }

}
