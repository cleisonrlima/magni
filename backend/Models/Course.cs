namespace backend.Models;

public class Course {


        public Course()
        {
            
        }

         public Course(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id {get; set;}

        public string name {get; set;}

        public IEnumerable<CourseDiscipline>? courseDisciplines {get; set;}

          public IEnumerable<Student>? students {get; set;} 

}