using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();

    }
}
