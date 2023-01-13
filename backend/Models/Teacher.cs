namespace backend.Models;

public class Teacher
{


    public Teacher()
    {

    }

    public Teacher(int id, string name, string birthDate, float salaryAmount)
    {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.salaryAmount = salaryAmount;
    }

    public int id { get; set; }
    public string name { get; set; }

    public string birthDate { get; set; }

    public float salaryAmount { get; set; }

}