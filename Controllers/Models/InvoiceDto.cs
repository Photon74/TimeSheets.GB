using System;
using System.Collections.Generic;

namespace TimeSheets.GB.Controllers.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPayed { get; set; }
        public DateTime PayDate { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
