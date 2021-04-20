using System;

namespace PrivateSchoolDatabase
{
    class Assignment
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _subDateTime;
        public DateTime SubDateTime
        {
            get { return _subDateTime; }
            set { _subDateTime = value; }
        }

        private double _oralMark;
        public double OralMark
        {
            get { return _oralMark; }
            set { _oralMark = value; }
        }

        private double _totalMark;
        public double TotalMark
        {
            get { return _totalMark; }
            set { _totalMark = value; }
        }

        public int AssignmentId { get; set; }

        public Assignment()
        {

        }

        public Assignment(string title, string description, DateTime subDateTime, double oralMark, double totalMark)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "The title of the assignment cannot be null or empty!");
            }
            Title = title;
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("description", "The description of the assignment cannot be null or empty!");
            }
            Description = description;
            SubDateTime = subDateTime;
            if (oralMark < 0)
            {
                throw new ArgumentOutOfRangeException("oralMark", "Oral Mark cannot be negative!");
            }
            OralMark = oralMark;
            if (TotalMark < 0)
            {
                throw new ArgumentOutOfRangeException("totalMark", "Total Mark cannot be negative!");
            }
            TotalMark = totalMark;
        }

        public Assignment(int assignmentId, string title, string description, DateTime subDateTime, double oralMark, double totalMark)
        {
            AssignmentId = assignmentId;
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "The title of the assignment cannot be null or empty!");
            }
            Title = title;
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("description", "The description of the assignment cannot be null or empty!");
            }
            Description = description;
            SubDateTime = subDateTime;
            if (oralMark < 0)
            {
                throw new ArgumentOutOfRangeException("oralMark", "Oral Mark cannot be negative!");
            }
            OralMark = oralMark;
            if (TotalMark < 0)
            {
                throw new ArgumentOutOfRangeException("totalMark", "Total Mark cannot be negative!");
            }
            TotalMark = totalMark;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Assignment objAsAssignment = obj as Assignment;
            if (objAsAssignment == null) return false;
            else return Equals(objAsAssignment);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Assignment other)
        {
            if (other == null) return false;
            return Title.Equals(other.Title) && Description.Equals(other.Description) && SubDateTime == other.SubDateTime &&
                    OralMark == other.OralMark && TotalMark == other.TotalMark;
        }

        public override string ToString()
        {
            return String.Format("{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", AssignmentId, Title, Description, SubDateTime.ToString("dd'/'MM'/'yyyy HH:mm:ss"), OralMark, TotalMark);
        }
    }
}
