namespace AishwaryaProject.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        int UpdateStudent(Student student);
    }
}
