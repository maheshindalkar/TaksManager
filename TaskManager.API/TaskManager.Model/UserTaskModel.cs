using System;

namespace TaskManager.Model
{
    public class UserTaskModel
    {
        public int Task_ID { get; set; }
        public int? ParentTask_ID { get; set; }
        public string TaskDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
    }
}
