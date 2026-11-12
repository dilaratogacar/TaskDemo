using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TaskDto
    {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Priority { get; set; } = string.Empty;

            public string StatusName { get; set; } = string.Empty;      // Status.Name
            public string CategoryName { get; set; } = string.Empty;    // Categories.Name

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        
    }
}
