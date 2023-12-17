using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PostedDate { get; set; }
        
    }
}