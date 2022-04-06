using System.Collections.Generic;

namespace TimeSheets.GB.Controllers.Models
{
    public class EmployeeEntity : MainEntity
    {
        public List<TaskEntity> Tasks { get; set; }
    }
}
