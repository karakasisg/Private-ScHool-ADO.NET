using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolDatabase
{
    class AssignmentsPerCoursePerStudent
    {
        private List<AssignmentsPerCourse> _assignmentsPerCourse;
        public Student Student { get; set; }

        public AssignmentsPerCoursePerStudent()
        {
            _assignmentsPerCourse = new List<AssignmentsPerCourse>();
        }

        public AssignmentsPerCoursePerStudent(Student student)
        {
            Student = student;
            _assignmentsPerCourse = new List<AssignmentsPerCourse>();
        }

        public void AddNewAssignmentsPerCourseList(Course course)
        {
            _assignmentsPerCourse.Add(new AssignmentsPerCourse(course));
        }

        public void ListAssignmentsOfACourse(Course course)
        {
            if (_assignmentsPerCourse.Find(x => x.Course.Equals(course)) == null)
            {
                throw new ArgumentException("course", "This course does not exist or does not have any assignments.");
            }
            _assignmentsPerCourse.Find(x => x.Course.Equals(course)).ListAssignmentsTwoTabs();
        }

        public void AddAssignmentOfACourseToStudent(Course course, Assignment assignment)
        {
            int index = _assignmentsPerCourse.FindIndex(x => x.Course.Equals(course));
            if (index < 0 || index >= _assignmentsPerCourse.Count)
            {
                throw new ArgumentException("course", "This course does not exist or does not have any assignments.");
            }
            _assignmentsPerCourse[index].AddAssignment(assignment);
        }

        public bool AssignmentsPerCourseListExistsAssignmentWithId(int courseId, int assignmentId)
        {
            if (_assignmentsPerCourse.Find(x => x.Course.CourseId == courseId) == null)
            {
                return false;
            }
            return _assignmentsPerCourse.Find(x => x.Course.CourseId == courseId).AssignmentsListExistsAssignmentWithId(assignmentId);
        }

        public bool AssignmentsPerCourseListContainsCourse(Course course)
        {
            return _assignmentsPerCourse.Exists(x => x.Course.Equals(course));
        }
    }
}
