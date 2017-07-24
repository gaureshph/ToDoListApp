using System;

namespace ToDoList.Services.ViewModels
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public string UserId { get; set; }
    }
}