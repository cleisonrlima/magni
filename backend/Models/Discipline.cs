namespace backend.Models;

public class Discipline
{


    public Discipline()
    {

    }

    public Discipline(int id, string name, int teacherId)
    {
        this.id = id;
        this.name = name;
        this.teacherId = teacherId;
    }

    public int id { get; set; }

    public string name { get; set; }

    public int teacherId { get; set; }

    public Teacher teacher { get; set; }

    public IEnumerable<CourseDiscipline>? courseDisciplines { get; set; }

      public IEnumerable<Grade>? grades { get; set; }
}