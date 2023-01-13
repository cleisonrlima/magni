using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;


public class DataContext : DbContext
{

    public DataContext()
    
    {
    }


    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        var configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();

        var connectionString = configuration.GetConnectionString("SqliteConn");
        options.UseSqlite(connectionString);

        if (!options.IsConfigured)
        {
            options.UseSqlite("A FALLBACK CONNECTION STRING");
        }
    }
    public DbSet<Student> students { get; set; }
    public DbSet<Teacher> teachers { get; set; }
    public DbSet<Discipline> disciplines { get; set; }
    public DbSet<Grade> grades { get; set; }
    public DbSet<Course> courses { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Grade>()
                   .HasKey(G => new { G.disciplineId, G.studentId });


        builder.Entity<CourseDiscipline>()
                    .HasKey(CD => new { CD.courseId, CD.disciplineId });



        builder.Entity<Teacher>().HasData(new List<Teacher>{
        new Teacher(1,"Cleison Lima","14/12/1982", 7000),
        new Teacher(2,"Marcelo Pires","14/12/1982", 7200),
        new Teacher(3,"Cristiao Ronaldo","14/12/1982", 2000),


       });

        builder.Entity<Discipline>().HasData(new List<Discipline>{
        new Discipline(1,"Logica de Programacao", 1),
        new Discipline(2,"Matematica I", 2),
        new Discipline(3,"Propabilidade I", 3),

       });



        builder.Entity<Course>().HasData(new List<Course>{
          new Course(1,"Ciencia da Computação"),
          new Course(2,"Direito")

       });

        builder.Entity<CourseDiscipline>().HasData(new List<CourseDiscipline>{
        new CourseDiscipline(){courseId=1, disciplineId = 1},
        new CourseDiscipline(){courseId = 1, disciplineId=2},
        new CourseDiscipline(){courseId = 1, disciplineId=3},
        new CourseDiscipline(){courseId = 2, disciplineId=2},
        new CourseDiscipline(){courseId = 2, disciplineId=3},

   });


        builder.Entity<Student>().HasData(new List<Student>{
        new Student(1,"Cleison Estudante", "XAXA1234",1, "14/12/1982"),
        new Student(2,"Marcelo Pires", "XAXA2333", 2,  "14/12/1982"),
       });


        builder.Entity<Grade>().HasData(new List<Grade>{
        new Grade(){disciplineId = 1, studentId=1, score = 8},
        new Grade(){disciplineId = 2, studentId=1, score = 5},
        new Grade(){disciplineId = 3, studentId=1, score = 10},
        new Grade(){disciplineId = 2, studentId=2, score = 10},
        new Grade(){disciplineId = 3, studentId=2, score = 10},

       });




    }

}