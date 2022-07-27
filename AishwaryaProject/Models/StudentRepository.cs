namespace AishwaryaProject.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            var students = appDbContext.Students;
            return students;
        }

        public int UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
