namespace BlogApp.Data{
    
    public class Repository{

        private static readonly List<Blog> _blog = new();

        static Repository(){
            _blog = new List<Blog>(){
                new Blog { Id = 1,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 2,Image="csgo.jpg", Title = "Second Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 3,Image="1.png", Title = "Third Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 4,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 5,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 6,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 7,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
                new Blog { Id = 8,Image="1.png", Title = "First Blog Post", Description = "Description Of First Blog", Author = "ToykanA", PostedDate = DateTime.Now },
            };
        }

        public static List<Blog> blogs{
            get{
                return _blog;
            }
        }
    
        public static Blog? GetById(int id){
            return _blog.FirstOrDefault(b => b.Id == id);
        }
    
    
    
    
    }
}