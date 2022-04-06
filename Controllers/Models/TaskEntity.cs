using System;

namespace TimeSheets.GB.Controllers.Models
{
    public class TaskEntity : MainEntity
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
    }
}
