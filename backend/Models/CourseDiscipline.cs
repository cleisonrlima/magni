namespace backend.Models;


public class CourseDiscipline
{

    public CourseDiscipline()
    {
        
    }

    public CourseDiscipline(int courseId, int disciplineId)
    {
        this.disciplineId = disciplineId;
        this.courseId = courseId;
    }
    public int courseId { get; set; }
    public Course course { get; set; }


    public int disciplineId { get; set; }

    public Discipline discipline { get; set; }
}