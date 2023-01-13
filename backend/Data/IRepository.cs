using backend.Models;

namespace backend.Data;

public interface IRepository
{

    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    Task<bool> SaveChangesSync();

    //Student
    Task<Student[]> getAllStudents(bool includeGrades);
    Task<Student> getStudentById(int studentId, bool includeGrades);

     Task<Student[]> getStudentsGradeByCourseId(int courseId, bool includeGrades);


    Task<Course[]> getCourses();
    Task<Course> getCourseById(int courseId);



    Task<Discipline[]> getDisciplines();
    Task<Discipline> getDisciplineById(int discipline);



    Task<Teacher[]> getTeachers();
    Task<Teacher> getTeacherById(int teacherId);



}