using System.Collections.Generic;

namespace TimeSheets.GB.Controllers.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContractDto> Contracts { get; set; }
    }
}
