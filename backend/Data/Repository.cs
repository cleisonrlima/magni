using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;


public class Repository : IRepository
{

    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        this._context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<Student[]> getAllStudents(bool includeGrades)
    {
        IQueryable<Student> query = _context.students.Include(q => q.course);

        if (includeGrades)
        {
            query = query.Include(q => q.grades).ThenInclude(q => q.discipline);

        }

        return await query.AsNoTracking().ToArrayAsync();
    }

    public async Task<Course> getCourseById(int courseId)
    {
        IQueryable<Course> query = _context.courses.Where(course => course.id == courseId);
        // .Include(q => q.courseDisciplines)
        // .ThenInclude(q => q.discipline.grades)
        // .ThenInclude(q => q.student)
        // .Include(q => q.courseDisciplines)
        // .ThenInclude(q => q.discipline.teacher).Where(course => course.id == courseId);

        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<Course[]> getCourses()
    {
        IQueryable<Course> query = _context.courses.Include(q => q.courseDisciplines).ThenInclude(q => q.discipline)
        .Include(q => q.students);

        return await query.ToArrayAsync();
    }

    public async Task<Discipline> getDisciplineById(int disciplineId)
    {
        IQueryable<Discipline> query = _context.disciplines
        .Include(q => q.teacher)
        .Include(q => q.grades)
        .ThenInclude(q => q.student);

         query = query.AsNoTracking().Where(discipline => discipline.id == disciplineId);

        return await query.FirstOrDefaultAsync();
    }


    public async Task<Discipline[]> getDisciplines()
    {
        IQueryable<Discipline> query = _context.disciplines.Include(q => q.teacher);

        return await query.ToArrayAsync();
    }

    public async Task<Student> getStudentById(int studentId, bool includeGrades)
    {
        IQueryable<Student> query = _context.students;

        if (includeGrades)
        {

            query = query.Include(q => q.course).Include(q => q.grades).ThenInclude(q => q.discipline);

        }

        query = query.AsNoTracking().OrderBy(student => student.id).Where(student => student.id == studentId);

        return await query.FirstOrDefaultAsync();
    }
    


        public async Task<Student[]> getStudentsGradeByCourseId(int courseId, bool includeGrades)
    {
        IQueryable<Student> query = _context.students;

        if (includeGrades)
        {

            query = query.Include(q => q.course).Include(q => q.grades).ThenInclude(q => q.discipline);

        }

        query = query.AsNoTracking().OrderBy(student => student.id).Where(student => student.courseId == courseId);

        return await query.ToArrayAsync();
    }
    public async Task<bool> SaveChangesSync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }




    public async Task<Teacher> getTeacherById(int teacherId)
    {
        IQueryable<Teacher> query = _context.teachers;

        query = query.AsNoTracking().OrderBy(teacher => teacher.id).Where(teacher => teacher.id == teacherId);

        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<Teacher[]> getTeachers()
    {
        IQueryable<Teacher> query = _context.teachers;




        return await query.ToArrayAsync();
    }

}