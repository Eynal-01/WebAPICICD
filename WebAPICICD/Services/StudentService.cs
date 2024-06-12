using WebAPICICD.Entities;

namespace WebAPICICD.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FullName="John Johnlu",
                Score  =98
            },
             new Student
            {
                Id = 2,
                FullName="Bob Memmedov",
                Score  =75
            }
        };
        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Delete(int id)
        {
            var item = students.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                students.Remove(item);
            }
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);

        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void Update(Student student)
        {
            var item = students.FirstOrDefault(x => x.Id == student.Id);
            if (item != null)
            {
                item.Score = student.Score;
                item.FullName = student.FullName;
            }
        }
    }
}
