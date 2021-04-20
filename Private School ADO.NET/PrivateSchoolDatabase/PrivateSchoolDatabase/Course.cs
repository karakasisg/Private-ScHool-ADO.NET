using System;
using System.Collections.Generic;

namespace PrivateSchoolDatabase
{
    
    
    class Course
    {

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private StreamValue _stream;
        public StreamValue Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        private TypeValue _type;
        public TypeValue Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public int CourseId { get; set; }

        public Course()
        {

        }

        public Course(string title, StreamValue stream, TypeValue type, DateTime startDate, DateTime endDate)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "Course's title cannot be null or empty!");
            }
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Course(int courseId, string title, StreamValue stream, TypeValue type, DateTime startDate, DateTime endDate)
        {
            CourseId = courseId;
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "Course's title cannot be null or empty!");
            }
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Course objAsCourse = obj as Course;
            if (objAsCourse == null) return false;
            else return Equals(objAsCourse);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Course other)
        {
            if (other == null) return false;
            return Title.Equals(other.Title) && Stream == other.Stream && Type == other.Type && 
                    StartDate == other.StartDate && EndDate == other.EndDate; 
        }

        public override string ToString()
        {
            return String.Format("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", CourseId,
                Title, Stream == StreamValue.CSharp ? "C#" : "Java", Type == TypeValue.Full_Time ? "Full-Time" : "Part-Time", 
                StartDate.ToString("dd'/'MM'/'yyyy"), EndDate.ToString("dd'/'MM'/'yyyy"));
        }
    }
}
