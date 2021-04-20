using System;

namespace PrivateSchoolDatabase
{
    class Trainer : Human
    {
        // We define Subject/_subject as string because we suppose that it can take any value
        // If it could take specific values, an enum type could be used
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public int TrainerId { get; set; }

        public Trainer() : base() { }

        public Trainer(string firstName, string lastName, string subject) : base(firstName, lastName)
        {
            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException("subject", "Trainer's subject cannot be null or empty!");
            }
            Subject = subject;
        }

        public Trainer(int trainerId, string firstName, string lastName, string subject) : base(firstName, lastName)
        {
            TrainerId = trainerId;
            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException("subject", "Trainer's subject cannot be null or empty!");
            }
            Subject = subject;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Trainer objAsTrainer = obj as Trainer;
            if (objAsTrainer == null) return false;
            else return Equals(objAsTrainer);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Trainer other)
        {
            if (other == null) return false;
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Subject.Equals(other.Subject);
        }

        public override string ToString()
        {
            return String.Format("{0, -11} {1, -22} {2, -32} {3, -52}", TrainerId, FirstName, LastName, Subject);
        }
    }
}
