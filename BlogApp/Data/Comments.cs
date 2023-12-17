using System.ComponentModel.DataAnnotations;
namespace BlogApp.Data{

public class Comments{

        [Key]
        public int CommentId { get; set; }
        public string? UserComment { get; set; }

    }



}