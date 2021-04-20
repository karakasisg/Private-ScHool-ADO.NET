using System;
using System.Collections.Generic;

namespace PrivateSchoolDatabase
{
    class Student : Human
    {
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private decimal _tuitionFees;
        public decimal TuitionFees
        {
            get { return _tuitionFees; }
            set { _tuitionFees = value; }
        }

        public int StudentId { get; set; }

        public Student() : base() 
        {

        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees) : base(firstName, lastName)
        {
            if (dateOfBirth.CompareTo(DateTime.Now) > 0)
            {
                throw new ArgumentOutOfRangeException("dateOfBirth", "The date you have inserted has not come yet!");
            }
            DateOfBirth = dateOfBirth;
            if (tuitionFees < 0)
            {
                throw new ArgumentOutOfRangeException("tuitionFees", "Tuition fees cannot be a negative number!");
            }
            TuitionFees = tuitionFees;
        }

        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees) : base(firstName, lastName)
        {
            StudentId = studentId;
            if (dateOfBirth.CompareTo(DateTime.Now) > 0)
            {
                throw new ArgumentOutOfRangeException("dateOfBirth", "The date you have inserted has not come yet!");
            }
            DateOfBirth = dateOfBirth;
            if (tuitionFees < 0)
            {
                throw new ArgumentOutOfRangeException("tuitionFees", "Tuition fees cannot be a negative number!");
            }
            TuitionFees = tuitionFees;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Student objAsStudent = obj as Student;
            if (objAsStudent == null) return false;
            else return Equals(objAsStudent);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && 
                   DateOfBirth == other.DateOfBirth && TuitionFees == other.TuitionFees;
        }

        public override string ToString()
        {
            return String.Format("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", StudentId,
                FirstName, LastName, DateOfBirth.ToString("dd'/'MM'/'yyyy"), TuitionFees.ToString("F"));
        }
    }
}
