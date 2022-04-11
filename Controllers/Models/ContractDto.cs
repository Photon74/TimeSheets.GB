namespace TimeSheets.GB.Controllers.Models
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public InvoiceDto Invoice { get; set; }
    }
}
