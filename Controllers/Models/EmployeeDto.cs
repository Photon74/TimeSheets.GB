using System.Collections.Generic;

namespace TimeSheets.GB.Controllers.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
