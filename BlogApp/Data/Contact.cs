using System.ComponentModel.DataAnnotations;
namespace BlogApp.Data{

public class Contact{

        [Key]
        public int ContactId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Eposta { get; set;}
        public string? Telephone { get; set; }
        public string? Message { get; set; }

    }



}