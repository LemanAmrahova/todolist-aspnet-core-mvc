using System;
using System.Collections.Generic;

namespace TodoList.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
    }
}
