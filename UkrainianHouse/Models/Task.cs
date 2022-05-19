using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string EmpTaskInfo { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Status Status { get; set; }
    }
}
