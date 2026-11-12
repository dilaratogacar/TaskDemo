using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class StatusUpdateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}

