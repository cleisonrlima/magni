namespace backend.Models;

public class Student
{

    public Student() { }

    public Student(int id, string name, string registrationNumber, int courseId, string birthDate)
    {
        this.id = id;
        this.name = name;
        this.registrationNumber = registrationNumber;
        this.courseId = courseId;
        this.birthDate = birthDate;
    }

    public int id { get; set; }
    public string name { get; set; }


    public string registrationNumber { get; set; }

    public string? birthDate { get; set; }

    public int? courseId { get; set; }

    public  Course? course { get; set; }

    public IEnumerable<Grade>? grades { get; set; }

}