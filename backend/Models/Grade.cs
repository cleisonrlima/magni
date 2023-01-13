namespace backend.Models;

public class Grade
{
    public Grade()
    {
    }

    Grade(int disciplineId, int studentId, float score)
    {
        this.disciplineId = disciplineId;
        this.studentId = studentId;
        this.score = score;
    }


    public int disciplineId { get; set; }
    public int studentId { get; set; }


    public Discipline discipline { get; set; }

    public Student student { get; set; }

    public float score { get; set; }

}