using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolDatabase
{
    class AssignmentsPerCourse
    {
        private List<Assignment> _assignments;
        public Course Course { get; set; }
        
        public AssignmentsPerCourse()
        {
            _assignments = new List<Assignment>();
        }

        public AssignmentsPerCourse(Course course)
        {
            Course = course;
            _assignments = new List<Assignment>();
        }

        public void ListAssignments()
        {
            for (int i = 0; i < _assignments.Count; i++)
            {
                Console.WriteLine("\t" + _assignments[i]);
            }
        }

        public void ListAssignmentsTwoTabs()
        {
            for (int i = 0; i < _assignments.Count; i++)
            {
                Console.WriteLine("\t\t" + _assignments[i]);
            }
        }

        public bool AssignmentsListExistsAssignmentWithId(int assignmentId)
        {
            return _assignments.Exists(x => x.AssignmentId == assignmentId);
        }

        public void AddAssignment(Assignment assignment)
        {
            _assignments.Add(assignment);
        }

        public Assignment GetAssignmentFromList(int index)
        {
            if (index < 0 || index >= _assignments.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or equal/greater than size of the list.");
            }
            return _assignments[index];
        }

        public Assignment GetAssignmentFromListWithId(int assignmentId)
        {
            if (_assignments.Find(x => x.AssignmentId == assignmentId) == null)
            {
                throw new ArgumentException("assignmendId", "There is not an assignment with this AssignmentId.");
            }
            return _assignments.Find(x => x.AssignmentId == assignmentId);
        }

        public int GetAssignmentsListSize()
        {
            return _assignments.Count;
        }
    }
}
