using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolDatabase
{
    class StudentsPerCourse
    {
        private List<Student> _students;
        public Course Course { get; set; }
        
        public StudentsPerCourse()
        {
            _students = new List<Student>();
        }

        public StudentsPerCourse(Course course)
        {
            Course = course;
            _students = new List<Student>();
        }

        public void ListStudents()
        {
            for (int i = 0; i < _students.Count; i++)
            {
                Console.WriteLine("\t" + _students[i]);
            }
        }
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public bool StudentsListContains(Student student)
        {
            return _students.Contains(student);
        }

        public bool StudentsListExistsStudentWithId(int studentId)
        {
            return _students.Exists(x => x.StudentId == studentId);
        }

        public int GetStudentsListSize()
        {
            return _students.Count;
        }

        public Student GetStudentFromList(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or equal/greater than size of the list.");
            }
            return _students[index];
        }
    }
}
